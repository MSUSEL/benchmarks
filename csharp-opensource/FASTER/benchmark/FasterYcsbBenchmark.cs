﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

#pragma warning disable 0162

//#define DASHBOARD

using FASTER.core;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace FASTER.benchmark
{
    public class FASTER_YcsbBenchmark
    {
        public enum Op : ulong
        {
            Upsert = 0,
            Read = 1,
            ReadModifyWrite = 2
        }

#if DEBUG
        const bool kUseSmallData = true;
        const bool kUseSyntheticData = true;
#else
        const bool kUseSmallData = false;
        const bool kUseSyntheticData = false;
#endif
        const long kInitCount = kUseSmallData ? 2500480 : 250000000;
        const long kTxnCount = kUseSmallData ? 10000000 : 1000000000;
        const int kMaxKey = kUseSmallData ? 1 << 22 : 1 << 28;

        const int kFileChunkSize = 4096;
        const long kChunkSize = 640;

        Key[] init_keys_;

        Key[] txn_keys_;

        long idx_ = 0;

        Input[] input_;
        readonly IDevice device;

        readonly FasterKV<Key, Value, Input, Output, Empty, Functions> store;

        long total_ops_done = 0;

        readonly int threadCount;
        readonly int numaStyle;
        readonly string distribution;
        readonly int readPercent;

        const int kRunSeconds = 30;
        const int kCheckpointSeconds = -1;

        volatile bool done = false;

        public FASTER_YcsbBenchmark(int threadCount_, int numaStyle_, string distribution_, int readPercent_)
        {
            threadCount = threadCount_;
            numaStyle = numaStyle_;
            distribution = distribution_;
            readPercent = readPercent_;

#if DASHBOARD
            statsWritten = new AutoResetEvent[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                statsWritten[i] = new AutoResetEvent(false);
            }
            threadThroughput = new double[threadCount];
            threadAverageLatency = new double[threadCount];
            threadMaximumLatency = new double[threadCount];
            threadProgress = new long[threadCount];
            writeStats = new bool[threadCount];
            freq = Stopwatch.Frequency;
#endif

            device = Devices.CreateLogDevice("C:\\data\\hlog");

            store = new FasterKV<Key, Value, Input, Output, Empty, Functions>
                (kMaxKey / 2, new Functions(), new LogSettings { LogDevice = device });
        }

        private void RunYcsb(int thread_idx)
        {
            RandomGenerator rng = new RandomGenerator((uint)(1 + thread_idx));

            if (numaStyle == 0)
                Native32.AffinitizeThreadRoundRobin((uint)thread_idx);
            else
                Native32.AffinitizeThreadShardedNuma((uint)thread_idx, 2); // assuming two NUMA sockets

            Stopwatch sw = new Stopwatch();
            sw.Start();


            Value value = default;
            Input input = default;
            Output output = default;

            long reads_done = 0;
            long writes_done = 0;

#if DASHBOARD
            var tstart = Stopwatch.GetTimestamp();
            var tstop1 = tstart;
            var lastWrittenValue = 0;
            int count = 0;
#endif

            var session = store.NewSession(null, true);

            while (!done)
            {
                long chunk_idx = Interlocked.Add(ref idx_, kChunkSize) - kChunkSize;
                while (chunk_idx >= kTxnCount)
                {
                    if (chunk_idx == kTxnCount)
                        idx_ = 0;
                    chunk_idx = Interlocked.Add(ref idx_, kChunkSize) - kChunkSize;
                }

                for (long idx = chunk_idx; idx < chunk_idx + kChunkSize && !done; ++idx)
                {
                    Op op;
                    int r = (int)rng.Generate(100);
                    if (r < readPercent)
                        op = Op.Read;
                    else if (readPercent >= 0)
                        op = Op.Upsert;
                    else
                        op = Op.ReadModifyWrite;

                    if (idx % 256 == 0)
                    {
                        session.Refresh();

                        if (idx % 65536 == 0)
                        {
                            session.CompletePending(false);
                        }
                    }

                    switch (op)
                    {
                        case Op.Upsert:
                            {
                                session.Upsert(ref txn_keys_[idx], ref value, Empty.Default, 1);
                                ++writes_done;
                                break;
                            }
                        case Op.Read:
                            {
                                Status result = session.Read(ref txn_keys_[idx], ref input, ref output, Empty.Default, 1);
                                if (result == Status.OK)
                                {
                                    ++reads_done;
                                }
                                break;
                            }
                        case Op.ReadModifyWrite:
                            {
                                Status result = session.RMW(ref txn_keys_[idx], ref input_[idx & 0x7], Empty.Default, 1);
                                if (result == Status.OK)
                                {
                                    ++writes_done;
                                }
                                break;
                            }
                        default:
                            throw new InvalidOperationException("Unexpected op: " + op);
                    }
                }

#if DASHBOARD
                count += (int)kChunkSize;

                //Check if stats collector is requesting for statistics
                if (writeStats[thread_idx])
                {
                    var tstart1 = tstop1;
                    tstop1 = Stopwatch.GetTimestamp();
                    threadProgress[thread_idx] = count;
                    threadThroughput[thread_idx] = (count - lastWrittenValue) / ((tstop1 - tstart1) / freq);
                    lastWrittenValue = count;
                    writeStats[thread_idx] = false;
                    statsWritten[thread_idx].Set();
                }
#endif
            }

            session.CompletePending(true);
            session.Dispose();

            sw.Stop();

            Console.WriteLine("Thread " + thread_idx + " done; " + reads_done + " reads, " +
                writes_done + " writes, in " + sw.ElapsedMilliseconds + " ms.");
            Interlocked.Add(ref total_ops_done, reads_done + writes_done);
        }

        public unsafe void Run()
        {
            Native32.AffinitizeThreadShardedNuma((uint)0, 2);

            RandomGenerator rng = new RandomGenerator();

            LoadData();

            input_ = new Input[8];
            for (int i = 0; i < 8; i++)
                input_[i].value = i;

#if DASHBOARD
            var dash = new Thread(() => DoContinuousMeasurements());
            dash.Start();
#endif

            Thread[] workers = new Thread[threadCount];

            Console.WriteLine("Executing setup.");

            // Setup the store for the YCSB benchmark.
            for (int idx = 0; idx < threadCount; ++idx)
            {
                int x = idx;
                workers[idx] = new Thread(() => SetupYcsb(x));
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Start threads.
            foreach (Thread worker in workers)
            {
                worker.Start();
            }
            foreach (Thread worker in workers)
            {
                worker.Join();
            }
            sw.Stop();
            Console.WriteLine("Loading time: {0}ms", sw.ElapsedMilliseconds);

            long startTailAddress = store.Log.TailAddress;
            Console.WriteLine("Start tail address = " + startTailAddress);


            idx_ = 0;
            Console.WriteLine(store.DumpDistribution());

            Console.WriteLine("Executing experiment.");

            // Run the experiment.
            for (int idx = 0; idx < threadCount; ++idx)
            {
                int x = idx;
                workers[idx] = new Thread(() => RunYcsb(x));
            }
            // Start threads.
            foreach (Thread worker in workers)
            {
                worker.Start();
            }

            Stopwatch swatch = new Stopwatch();
            swatch.Start();

            if (kCheckpointSeconds <= 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(kRunSeconds));
            }
            else
            {
                int runSeconds = 0;
                while (runSeconds < kRunSeconds)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(kCheckpointSeconds));
                    store.TakeFullCheckpoint(out Guid token);
                    runSeconds += kCheckpointSeconds;
                }
            }

            swatch.Stop();

            done = true;

            foreach (Thread worker in workers)
            {
                worker.Join();
            }

#if DASHBOARD
            dash.Abort();
#endif

            double seconds = swatch.ElapsedMilliseconds / 1000.0;
            long endTailAddress = store.Log.TailAddress;
            Console.WriteLine("End tail address = " + endTailAddress);

            Console.WriteLine("Total " + total_ops_done + " ops done " + " in " + seconds + " secs.");
            Console.WriteLine("##, " + distribution + ", " + numaStyle + ", " + readPercent + ", "
                + threadCount + ", " + total_ops_done / seconds + ", "
                + (endTailAddress - startTailAddress));
        }

        private void SetupYcsb(int thread_idx)
        {
            if (numaStyle == 0)
                Native32.AffinitizeThreadRoundRobin((uint)thread_idx);
            else
                Native32.AffinitizeThreadShardedNuma((uint)thread_idx, 2); // assuming two NUMA sockets

            var session = store.NewSession(null, true);

#if DASHBOARD
            var tstart = Stopwatch.GetTimestamp();
            var tstop1 = tstart;
            var lastWrittenValue = 0;
            int count = 0;
#endif

            Value value = default;

            for (long chunk_idx = Interlocked.Add(ref idx_, kChunkSize) - kChunkSize;
                chunk_idx < kInitCount;
                chunk_idx = Interlocked.Add(ref idx_, kChunkSize) - kChunkSize)
            {
                for (long idx = chunk_idx; idx < chunk_idx + kChunkSize; ++idx)
                {
                    if (idx % 256 == 0)
                    {
                        session.Refresh();

                        if (idx % 65536 == 0)
                        {
                            session.CompletePending(false);
                        }
                    }

                    session.Upsert(ref init_keys_[idx], ref value, Empty.Default, 1);
                }
#if DASHBOARD
                count += (int)kChunkSize;

                //Check if stats collector is requesting for statistics
                if (writeStats[thread_idx])
                {
                    var tstart1 = tstop1;
                    tstop1 = Stopwatch.GetTimestamp();
                    threadThroughput[thread_idx] = (count - lastWrittenValue) / ((tstop1 - tstart1) / freq);
                    lastWrittenValue = count;
                    writeStats[thread_idx] = false;
                    statsWritten[thread_idx].Set();
                }
#endif
            }

            session.CompletePending(true);
            session.Dispose();
        }

#if DASHBOARD
        int measurementInterval = 2000;
        bool allDone;
        bool measureLatency;
        bool[] writeStats;
        private EventWaitHandle[] statsWritten;
        double[] threadThroughput;
        double[] threadAverageLatency;
        double[] threadMaximumLatency;
        long[] threadProgress;
        double freq;

        void DoContinuousMeasurements()
        {

            if (numaStyle == 0)
                Native32.AffinitizeThreadRoundRobin((uint)threadCount + 1);
            else
                Native32.AffinitizeThreadShardedTwoNuma((uint)threadCount + 1);

            double totalThroughput, totalLatency, maximumLatency;
            double totalProgress;
            int ver = 0;

            using (var client = new WebClient())
            {
                while (!allDone)
                {
                    ver++;

                    Thread.Sleep(measurementInterval);

                    totalProgress = 0;
                    totalThroughput = 0;
                    totalLatency = 0;
                    maximumLatency = 0;

                    for (int i = 0; i < threadCount; i++)
                    {
                        writeStats[i] = true;
                    }


                    for (int i = 0; i < threadCount; i++)
                    {
                        statsWritten[i].WaitOne();
                        totalThroughput += threadThroughput[i];
                        totalProgress += threadProgress[i];
                        if (measureLatency)
                        {
                            totalLatency += threadAverageLatency[i];
                            if (threadMaximumLatency[i] > maximumLatency)
                            {
                                maximumLatency = threadMaximumLatency[i];
                            }
                        }
                    }

                    if (measureLatency)
                    {
                        Console.WriteLine("{0} \t {1:0.000} \t {2} \t {3} \t {4} \t {5}", ver, totalThroughput / (double)1000000, totalLatency / threadCount, maximumLatency, store.LogTailAddress, totalProgress);
                    }
                    else
                    {
                        Console.WriteLine("{0} \t {1:0.000} \t {2} \t {3}", ver, totalThroughput / (double)1000000, store.LogTailAddress, totalProgress);
                    }
                }
            }
        }
#endif

#region Load Data

        private unsafe void LoadDataFromFile(string filePath)
        {
            string init_filename = filePath + "\\load_" + distribution + "_250M_raw.dat";
            string txn_filename = filePath + "\\run_" + distribution + "_250M_1000M_raw.dat";

            long count = 0;
            using (FileStream stream = File.Open(init_filename, FileMode.Open, FileAccess.Read,
                FileShare.Read))
            {
                Console.WriteLine("loading keys from " + init_filename + " into memory...");
                init_keys_ = new Key[kInitCount];

                byte[] chunk = new byte[kFileChunkSize];
                GCHandle chunk_handle = GCHandle.Alloc(chunk, GCHandleType.Pinned);
                byte* chunk_ptr = (byte*)chunk_handle.AddrOfPinnedObject();

                long offset = 0;

                while (true)
                {
                    stream.Position = offset;
                    int size = stream.Read(chunk, 0, kFileChunkSize);
                    for (int idx = 0; idx < size; idx += 8)
                    {
                        init_keys_[count].value = *(long*)(chunk_ptr + idx);
                        ++count;
                    }
                    if (size == kFileChunkSize)
                        offset += kFileChunkSize;
                    else
                        break;

                    if (count == kInitCount)
                        break;
                }

                if (count != kInitCount)
                {
                    throw new InvalidDataException("Init file load fail!");
                }
            }

            Console.WriteLine("loaded " + kInitCount + " keys.");


            using (FileStream stream = File.Open(txn_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] chunk = new byte[kFileChunkSize];
                GCHandle chunk_handle = GCHandle.Alloc(chunk, GCHandleType.Pinned);
                byte* chunk_ptr = (byte*)chunk_handle.AddrOfPinnedObject();

                Console.WriteLine("loading txns from " + txn_filename + " into memory...");

                txn_keys_ = new Key[kTxnCount];

                count = 0;
                long offset = 0;

                while (true)
                {
                    stream.Position = offset;
                    int size = stream.Read(chunk, 0, kFileChunkSize);
                    for (int idx = 0; idx < size; idx += 8)
                    {
                        txn_keys_[count].value = *(long*)(chunk_ptr + idx);
                        ++count;
                    }
                    if (size == kFileChunkSize)
                        offset += kFileChunkSize;
                    else
                        break;

                    if (count == kTxnCount)
                        break;
                }

                if (count != kTxnCount)
                {
                    throw new InvalidDataException("Txn file load fail!" + count + ":" + kTxnCount);
                }
            }

            Console.WriteLine("loaded " + kTxnCount + " txns.");
        }

        private void LoadData()
        {
            if (kUseSyntheticData)
            {
                LoadSyntheticData();
                return;
            }

            string filePath = "C:\\ycsb_files";

            if (!Directory.Exists(filePath))
            {
                filePath = "D:\\ycsb_files";
            }
            if (!Directory.Exists(filePath))
            {
                filePath = "E:\\ycsb_files";
            }

            if (Directory.Exists(filePath))
            {
                LoadDataFromFile(filePath);
            }
            else
            {
                Console.WriteLine("WARNING: Could not find YCSB directory, loading synthetic data instead");
                LoadSyntheticData();
            }
        }

        private void LoadSyntheticData()
        {
            Console.WriteLine("Loading synthetic data (uniform distribution)");

            init_keys_ = new Key[kInitCount];
            long val = 0;
            for (int idx = 0; idx < kInitCount; idx++)
            {
                init_keys_[idx] = new Key { value = val++ };
            }

            Console.WriteLine("loaded " + kInitCount + " keys.");

            RandomGenerator generator = new RandomGenerator();

            txn_keys_ = new Key[kTxnCount];

            for (int idx = 0; idx < kTxnCount; idx++)
            {
                txn_keys_[idx] = new Key { value = (long)generator.Generate64(kInitCount) };
            }

            Console.WriteLine("loaded " + kTxnCount + " txns.");

        }
#endregion


    }
}
