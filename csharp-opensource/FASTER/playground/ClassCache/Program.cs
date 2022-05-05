﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using FASTER.core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCache
{
    class Program
    {
        // Whether we use read cache in this sample
        static readonly bool useReadCache = true;
        const int max = 1000000;

        static void Main()
        {
            // This sample shows the use of FASTER as a cache + key-value store for 
            // C# objects.

            // Create files for storing data
            // We set deleteOnClose to true, so logs will auto-delete on completion
            var log =  Devices.CreateLogDevice(Path.GetTempPath() + "hlog.log", deleteOnClose: true);
            var objlog = Devices.CreateLogDevice(Path.GetTempPath() + "hlog.obj.log", deleteOnClose: true);

            // We use context to store and report latency of async operations
            var context = default(CacheContext);

            // Define settings for log
            var logSettings = new LogSettings { LogDevice = log, ObjectLogDevice = objlog };
            if (useReadCache)
                logSettings.ReadCacheSettings = new ReadCacheSettings();

            var h = new FasterKV
                <CacheKey, CacheValue, CacheInput, CacheOutput, CacheContext, CacheFunctions>(
                1L << 20, new CacheFunctions(), logSettings,
                null, // no checkpoints in this sample
                // Provide serializers for key and value types
                new SerializerSettings<CacheKey, CacheValue> { keySerializer = () => new CacheKeySerializer(), valueSerializer = () => new CacheValueSerializer() }
                );

            // Thread starts session with FASTER
            var s = h.NewSession();

            Console.WriteLine("Writing keys from 0 to {0} to FASTER", max);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < max; i++)
            {
                if (i % (1<<19) == 0)
                {
                    long workingSet = Process.GetCurrentProcess().WorkingSet64;
                    Console.WriteLine($"{i}: {workingSet / 1048576}M");
                }
                var key = new CacheKey(i);
                var value = new CacheValue(i);
                s.Upsert(ref key, ref value, context, 0);
            }
            sw.Stop();
            Console.WriteLine("Total time to upsert {0} elements: {1:0.000} secs ({2:0.00} inserts/sec)", max, sw.ElapsedMilliseconds/1000.0, max / (sw.ElapsedMilliseconds / 1000.0));

            // Uncomment below to copy entire log to disk, but retain tail of log in memory
            // h.Log.Flush(true);

            // Uncomment below to move entire log to disk and eliminate data from memory as 
            // well. This will serve workload entirely from disk using read cache if enabled.
            // This will *allow* future updates to the store.
            // h.Log.FlushAndEvict(true);

            // Uncomment below to move entire log to disk and eliminate data from memory as 
            // well. This will serve workload entirely from disk using read cache if enabled.
            // This will *prevent* future updates to the store.
            h.Log.DisposeFromMemory();

            Console.Write("Enter read workload type (0 = random reads; 1 = interactive): ");
            var workload = int.Parse(Console.ReadLine());

            if (workload == 0)
                RandomReadWorkload(s, max);
            else
                InteractiveReadWorkload(s);

            // Stop session and clean up
            s.Dispose();
            h.Dispose();
            log.Close();
            objlog.Close();

            Console.WriteLine("Press <ENTER> to end");
            Console.ReadLine();
        }

        private static void RandomReadWorkload(ClientSession<CacheKey, CacheValue, CacheInput, CacheOutput, CacheContext, CacheFunctions> s, int max)
        {
            Console.WriteLine("Issuing uniform random read workload of {0} reads", max);

            var rnd = new Random(0);

            int statusPending = 0;
            var output = new CacheOutput();
            var context = new CacheContext();
            var input = default(CacheInput);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < max; i++)
            {
                long k = rnd.Next(max);

                var key = new CacheKey(k);
                var status = s.Read(ref key, ref input, ref output, context, 0);

                switch (status)
                {
                    case Status.PENDING:
                        statusPending++;
                        if (statusPending % 1000 == 0)
                            s.CompletePending(false);
                        break;
                    case Status.OK:
                        if (output.value.value != key.key)
                            throw new Exception("Read error!");
                        break;
                    default:
                        throw new Exception("Error!");
                }
            }
            s.CompletePending(true);
            sw.Stop();
            Console.WriteLine("Total time to read {0} elements: {1:0.000} secs ({2:0.00} reads/sec)", max, sw.ElapsedMilliseconds / 1000.0, max / (sw.ElapsedMilliseconds / 1000.0));
            Console.WriteLine($"Reads completed with PENDING: {statusPending}");
        }

        private static void InteractiveReadWorkload(ClientSession<CacheKey, CacheValue, CacheInput, CacheOutput, CacheContext, CacheFunctions> s)
        {
            Console.WriteLine("Issuing interactive read workload");

            var context = new CacheContext { type = 1 };

            while (true)
            {
                Console.Write("Enter key (int), -1 to exit: ");
                int k = int.Parse(Console.ReadLine());
                if (k == -1) break;

                var output = new CacheOutput();
                var input = default(CacheInput);
                var key = new CacheKey(k);

                context.ticks = DateTime.Now.Ticks;
                var status = s.Read(ref key, ref input, ref output, context, 0);
                switch (status)
                {
                    case Status.PENDING:
                        s.CompletePending(true);
                        break;
                    case Status.OK:
                        long ticks = DateTime.Now.Ticks - context.ticks;
                        if (output.value.value != key.key)
                            Console.WriteLine("Sync: Incorrect value {0} found, latency = {1}ms", output.value.value, new TimeSpan(ticks).TotalMilliseconds);
                        else
                            Console.WriteLine("Sync: Correct value {0} found, latency = {1}ms", output.value.value, new TimeSpan(ticks).TotalMilliseconds);
                        break;
                    default:
                        ticks = DateTime.Now.Ticks - context.ticks;
                        Console.WriteLine("Sync: Value not found, latency = {0}ms", new TimeSpan(ticks).TotalMilliseconds);
                        break;
                }
            }
        }
    }
}
