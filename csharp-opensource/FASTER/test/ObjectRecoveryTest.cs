﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FASTER.core;
using NUnit.Framework;

namespace FASTER.test.recovery.objectstore
{
    internal struct StructTuple<T1, T2>
    {
        public T1 Item1;
        public T2 Item2;
    }

    [TestFixture]
    internal class ObjectRecoveryTests
    {
        const long numUniqueKeys = (1 << 14);
        const long keySpace = (1L << 14);
        const long numOps = (1L << 19);
        const long completePendingInterval = (1L << 10);
        const long checkpointInterval = (1L << 16);
        private FasterKV<AdId, NumClicks, Input, Output, Empty, Functions> fht;
        private string test_path;
        private Guid token;
        private IDevice log, objlog;

        [SetUp]
        public void Setup()
        {
            if (test_path == null)
            {
                test_path = TestContext.CurrentContext.TestDirectory + "\\" + Path.GetRandomFileName();
                if (!Directory.Exists(test_path))
                    Directory.CreateDirectory(test_path);
            }

            log = Devices.CreateLogDevice(test_path + "\\ObjectRecoveryTests.log", false);
            objlog = Devices.CreateLogDevice(test_path + "\\ObjectRecoveryTests.obj.log", false);

            fht = new FasterKV<AdId, NumClicks, Input, Output, Empty, Functions>
                (
                    keySpace, new Functions(),
                    new LogSettings { LogDevice = log, ObjectLogDevice = objlog },
                    new CheckpointSettings { CheckpointDir = test_path, CheckPointType = CheckpointType.Snapshot },
                    new SerializerSettings<AdId, NumClicks> { keySerializer = () => new AdIdSerializer(), valueSerializer = () => new NumClicksSerializer() }
                    );
        }

        [TearDown]
        public void TearDown()
        {
            fht.Dispose();
            fht = null;
            log.Close();
            objlog.Close();
            DeleteDirectory(test_path);
        }

        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        [Test]
        public void ObjectRecoveryTest1()
        {
            Populate();
            fht.Dispose();
            fht = null;
            log.Close();
            objlog.Close();
            Setup();
            RecoverAndTest(token, token);
        }

        public unsafe void Populate()
        {
            // Prepare the dataset
            var inputArray = new StructTuple<AdId, Input>[numOps];
            for (int i = 0; i < numOps; i++)
            {
                inputArray[i] = new StructTuple<AdId, Input>
                {
                    Item1 = new AdId { adId = i % numUniqueKeys },
                    Item2 = new Input { numClicks = new NumClicks { numClicks = 1 } }
                };
            }

            // Register thread with FASTER
            var session = fht.NewSession();

            // Prpcess the batch of input data
            bool first = true;
            for (int i = 0; i < numOps; i++)
            {
                session.RMW(ref inputArray[i].Item1, ref inputArray[i].Item2, Empty.Default, i);

                if ((i + 1) % checkpointInterval == 0)
                {
                    if (first)
                        while (!fht.TakeFullCheckpoint(out token)) ;
                    else
                        while (!fht.TakeFullCheckpoint(out _)) ;

                    fht.CompleteCheckpointAsync().GetAwaiter().GetResult();

                    first = false;
                }

                if (i % completePendingInterval == 0)
                {
                    session.CompletePending(false);
                }
            }


            // Make sure operations are completed
            session.CompletePending(true);
            session.Dispose();
        }

        public unsafe void RecoverAndTest(Guid cprVersion, Guid indexVersion)
        {
            // Recover
            fht.Recover(cprVersion, indexVersion);

            // Create array for reading
            var inputArray = new StructTuple<AdId, Input>[numUniqueKeys];
            for (int i = 0; i < numUniqueKeys; i++)
            {
                inputArray[i] = new StructTuple<AdId, Input>
                {
                    Item1 = new AdId { adId = i },
                    Item2 = new Input { numClicks = new NumClicks { numClicks = 0 } }
                };
            }

            var outputArray = new Output[numUniqueKeys];
            for (int i = 0; i < numUniqueKeys; i++)
            {
                outputArray[i] = new Output();
            }

            // Register with thread
            var session = fht.NewSession();

            Input input = default;
            // Issue read requests
            for (var i = 0; i < numUniqueKeys; i++)
            {
                session.Read(ref inputArray[i].Item1, ref input, ref outputArray[i], Empty.Default, i);
            }

            // Complete all pending requests
            session.CompletePending(true);

            // Release
            session.Dispose();

            // Test outputs
            var checkpointInfo = default(HybridLogRecoveryInfo);
            checkpointInfo.Recover(cprVersion, new LocalCheckpointManager(test_path));

            // Compute expected array
            long[] expected = new long[numUniqueKeys];
            foreach (var guid in checkpointInfo.continueTokens.Keys)
            {
                var cp = checkpointInfo.continueTokens[guid];
                for (long i = 0; i <= cp.UntilSerialNo; i++)
                {
                    var id = i % numUniqueKeys;
                    expected[id]++;
                }
            }

            int threadCount = 1; // single threaded test
            int numCompleted = threadCount - checkpointInfo.continueTokens.Count;
            for (int t = 0; t < numCompleted; t++)
            {
                var sno = numOps;
                for (long i = 0; i < sno; i++)
                {
                    var id = i % numUniqueKeys;
                    expected[id]++;
                }
            }

            // Assert if expected is same as found
            for (long i = 0; i < numUniqueKeys; i++)
            {
                Assert.IsTrue(
                    expected[i] == outputArray[i].value.numClicks,
                    "Debug error for AdId {0}: Expected ({1}), Found({2})", 
                    inputArray[i].Item1.adId,
                    expected[i], 
                    outputArray[i].value.numClicks);
            }
        }
    }
}
