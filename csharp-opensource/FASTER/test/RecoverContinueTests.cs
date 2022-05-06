﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FASTER.core;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;

namespace FASTER.test.recovery.sumstore.recover_continue
{
    [TestFixture]
    internal class RecoverContinueTests
    {
        private FasterKV<AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions> fht1;
        private FasterKV<AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions> fht2;
        private FasterKV<AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions> fht3;
        private IDevice log;
        private int numOps;

        [SetUp]
        public void Setup()
        {
            log = Devices.CreateLogDevice(TestContext.CurrentContext.TestDirectory + "\\RecoverContinueTests.log", deleteOnClose: true);
            Directory.CreateDirectory(TestContext.CurrentContext.TestDirectory + "\\checkpoints3");

            fht1 = new FasterKV
                <AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions>
                (128, new SimpleFunctions(),
                logSettings: new LogSettings { LogDevice = log, MutableFraction = 0.1, MemorySizeBits = 29 },
                checkpointSettings: new CheckpointSettings { CheckpointDir = TestContext.CurrentContext.TestDirectory + "\\checkpoints3", CheckPointType = CheckpointType.Snapshot }
                );

            fht2 = new FasterKV
                <AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions>
                (128, new SimpleFunctions(),
                logSettings: new LogSettings { LogDevice = log, MutableFraction = 0.1, MemorySizeBits = 29 },
                checkpointSettings: new CheckpointSettings { CheckpointDir = TestContext.CurrentContext.TestDirectory + "\\checkpoints3", CheckPointType = CheckpointType.Snapshot }
                );

            fht3 = new FasterKV
                <AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions>
                (128, new SimpleFunctions(),
                logSettings: new LogSettings { LogDevice = log, MutableFraction = 0.1, MemorySizeBits = 29 },
                checkpointSettings: new CheckpointSettings { CheckpointDir = TestContext.CurrentContext.TestDirectory + "\\checkpoints3", CheckPointType = CheckpointType.Snapshot }
                );

            numOps = 5000;
        }

        [TearDown]
        public void TearDown()
        {
            fht1.Dispose();
            fht2.Dispose();
            fht3.Dispose();
            fht1 = null;
            fht2 = null;
            fht3 = null;
            log.Close();
            Directory.Delete(TestContext.CurrentContext.TestDirectory + "\\checkpoints3", true);
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
        public void RecoverContinueTest()
        {

            long sno = 0;

            var firstsession = fht1.NewSession("first");
            IncrementAllValues(ref firstsession, ref sno);
            fht1.TakeFullCheckpoint(out _);
            fht1.CompleteCheckpointAsync().GetAwaiter().GetResult();
            firstsession.Dispose();

            // Check if values after checkpoint are correct
            var session1 = fht1.NewSession();
            CheckAllValues(ref session1, 1);
            session1.Dispose();

            // Recover and check if recovered values are correct
            fht2.Recover();
            var session2 = fht2.NewSession();
            CheckAllValues(ref session2, 1);
            session2.Dispose();

            // Continue and increment values
            var continuesession = fht2.ResumeSession("first", out CommitPoint cp);
            long newSno = cp.UntilSerialNo;
            Assert.IsTrue(newSno == sno - 1);
            IncrementAllValues(ref continuesession, ref sno);
            fht2.TakeFullCheckpoint(out _);
            fht2.CompleteCheckpointAsync().GetAwaiter().GetResult();
            continuesession.Dispose();

            // Check if values after continue checkpoint are correct
            var session3 = fht2.NewSession();
            CheckAllValues(ref session3, 2);
            session3.Dispose();


            // Recover and check if recovered values are correct
            fht3.Recover();

            var nextsession = fht3.ResumeSession("first", out cp);
            long newSno2 = cp.UntilSerialNo;
            Assert.IsTrue(newSno2 == sno - 1);
            CheckAllValues(ref nextsession, 2);
            nextsession.Dispose();
        }

        private void CheckAllValues(
            ref ClientSession<AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions> fht,
            int value)
        {
            AdInput inputArg = default;
            Output outputArg = default;
            for (var key = 0; key < numOps; key++)
            {
                inputArg.adId.adId = key;
                var status = fht.Read(ref inputArg.adId, ref inputArg, ref outputArg, Empty.Default, key);

                if (status == Status.PENDING)
                    fht.CompletePending(true);
                else
                {
                    Assert.IsTrue(outputArg.value.numClicks == value);
                }
            }

            fht.CompletePending(true);
        }

        private void IncrementAllValues(
            ref ClientSession<AdId, NumClicks, AdInput, Output, Empty, SimpleFunctions> fht, 
            ref long sno)
        {
            AdInput inputArg = default;
            for (int key = 0; key < numOps; key++, sno++)
            {
                inputArg.adId.adId = key;
                inputArg.numClicks.numClicks = 1;
                fht.RMW(ref inputArg.adId, ref inputArg, Empty.Default, sno);
            }
            fht.CompletePending(true);
        }


    }

    public class SimpleFunctions : IFunctions<AdId, NumClicks, AdInput, Output, Empty>
    {
        public void RMWCompletionCallback(ref AdId key, ref AdInput input, Empty ctx, Status status)
        {
        }

        public void ReadCompletionCallback(ref AdId key, ref AdInput input, ref Output output, Empty ctx, Status status)
        {
            Assert.IsTrue(status == Status.OK);
            Assert.IsTrue(output.value.numClicks == key.adId);
        }

        public void UpsertCompletionCallback(ref AdId key, ref NumClicks input, Empty ctx)
        {
        }

        public void DeleteCompletionCallback(ref AdId key, Empty ctx)
        {
        }

        public void CheckpointCompletionCallback(string sessionId, CommitPoint commitPoint)
        {
            Console.WriteLine("Session {0} reports persistence until {1}", sessionId, commitPoint.UntilSerialNo);
        }

        // Read functions
        public void SingleReader(ref AdId key, ref AdInput input, ref NumClicks value, ref Output dst)
        {
            dst.value = value;
        }

        public void ConcurrentReader(ref AdId key, ref AdInput input, ref NumClicks value, ref Output dst)
        {
            dst.value = value;
        }

        // Upsert functions
        public void SingleWriter(ref AdId key, ref NumClicks src, ref NumClicks dst)
        {
            dst = src;
        }

        public bool ConcurrentWriter(ref AdId key, ref NumClicks src, ref NumClicks dst)
        {
            dst = src;
            return true;
        }

        // RMW functions
        public void InitialUpdater(ref AdId key, ref AdInput input, ref NumClicks value)
        {
            value = input.numClicks;
        }

        public bool InPlaceUpdater(ref AdId key, ref AdInput input, ref NumClicks value)
        {
            Interlocked.Add(ref value.numClicks, input.numClicks.numClicks);
            return true;
        }

        public void CopyUpdater(ref AdId key, ref AdInput input, ref NumClicks oldValue, ref NumClicks newValue)
        {
            newValue.numClicks += oldValue.numClicks + input.numClicks.numClicks;
        }
    }
}
