﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using FASTER.core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedSample
{
    public class MyKey : IFasterEqualityComparer<MyKey>
    {
        public int key;

        public long GetHashCode64(ref MyKey key)
        {
            return Utility.GetHashCode(key.key);
        }

        public bool Equals(ref MyKey k1, ref MyKey k2)
        {
            return k1.key == k2.key;
        }
    }

    public class MyKeySerializer : BinaryObjectSerializer<MyKey>
    {
        public override void Serialize(ref MyKey key)
        {
            writer.Write(key.key);
        }

        public override void Deserialize(ref MyKey key)
        {
            key.key = reader.ReadInt32();
        }
    }


    public class MyValue
    {
        public int value;
    }

    public class MyValueSerializer : BinaryObjectSerializer<MyValue>
    {
        public override void Serialize(ref MyValue value)
        {
            writer.Write(value.value);
        }

        public override void Deserialize(ref MyValue value)
        {
            value.value = reader.ReadInt32();
        }
    }

    public class MyInput
    {
    }

    public class MyOutput
    {
        public MyValue value;
    }


    public class MyContext
    {
    }

    public class MyFunctions : IFunctions<MyKey, MyValue, MyInput, MyOutput, MyContext>
    {
        public void ConcurrentReader(ref MyKey key, ref MyInput input, ref MyValue value, ref MyOutput dst)
        {
            throw new NotImplementedException();
        }

        public void ConcurrentWriter(ref MyKey key, ref MyValue src, ref MyValue dst)
        {
            throw new NotImplementedException();
        }

        public void CopyUpdater(ref MyKey key, ref MyInput input, ref MyValue oldValue, ref MyValue newValue)
        {
            throw new NotImplementedException();
        }

        public void InitialUpdater(ref MyKey key, ref MyInput input, ref MyValue value)
        {
            throw new NotImplementedException();
        }

        public void InPlaceUpdater(ref MyKey key, ref MyInput input, ref MyValue value)
        {
            throw new NotImplementedException();
        }

        public void CheckpointCompletionCallback(Guid sessionId, long serialNum)
        {
            throw new NotImplementedException();
        }

        public void ReadCompletionCallback(ref MyKey key, ref MyInput input, ref MyOutput output, MyContext ctx, Status status)
        {
            throw new NotImplementedException();
        }

        public void RMWCompletionCallback(ref MyKey key, ref MyInput input, MyContext ctx, Status status)
        {
            throw new NotImplementedException();
        }

        public void SingleReader(ref MyKey key, ref MyInput input, ref MyValue value, ref MyOutput dst)
        {
            throw new NotImplementedException();
        }

        public void SingleWriter(ref MyKey key, ref MyValue src, ref MyValue dst)
        {
            throw new NotImplementedException();
        }

        public void UpsertCompletionCallback(ref MyKey key, ref MyValue value, MyContext ctx)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var log = Devices.CreateLogDevice(Path.GetTempPath() + "hlog.log");
            var objlog = Devices.CreateLogDevice(Path.GetTempPath() + "hlog.obj.log");

            var h = new FasterKV
                <MyKey, MyValue, MyInput, MyOutput, MyContext, MyFunctions>
                (1L << 20, new MyFunctions(),
                new LogSettings { LogDevice = log, ObjectLogDevice = objlog, MemorySizeBits = 29 }
                );

            var context = default(MyContext);

            h.StartSession();

            for (int i = 0; i < 20000; i++)
            {
                var _key = new MyKey { key = i };
                var value = new MyValue { value = i };
                h.Upsert(ref _key, ref value, context, 0);
                if (i % 32 == 0) h.Refresh();
            }
            var key = new MyKey { key = 23 };
            var input = default(MyInput);
            MyOutput g1 = new MyOutput();
            h.Read(ref key, ref input, ref g1, context, 0);

            h.CompletePending(true);

            MyOutput g2 = new MyOutput();
            key = new MyKey { key = 46 };
            h.Read(ref key, ref input, ref g2, context, 0);
            h.CompletePending(true);

            Console.WriteLine("Success!");
            Console.ReadLine();
        }
    }
}
