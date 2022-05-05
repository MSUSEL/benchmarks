﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using System.Linq;
using FASTER.core;

namespace ClassRecoveryDurablity
{
    public class Types
    {
        public class StoreKey : IFasterEqualityComparer<StoreKey>
        {
            public byte[] key;
            public string tableType;

            public virtual long GetHashCode64(ref StoreKey key)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(key.tableType);
                byte[] b = bytes.ToArray().Concat(key.key).ToArray();

                var hash256 = Program.Hash256(b);

                long res = 0;
                foreach (byte bt in hash256)
                    res = res * 31 * 31 * bt + 17;

                return res;
            }

            public virtual bool Equals(ref StoreKey k1, ref StoreKey k2)
            {
                return k1.key.SequenceEqual(k2.key) && k1.tableType == k2.tableType;
            }
        }

        public class StoreKeySerializer : BinaryObjectSerializer<StoreKey>
        {
            public override void Deserialize(ref StoreKey obj)
            {
                var bytesr = new byte[4];
                reader.Read(bytesr, 0, 4);
                var sizet = BitConverter.ToInt32(bytesr);
                var bytes = new byte[sizet];
                reader.Read(bytes, 0, sizet);
                obj.tableType = System.Text.Encoding.UTF8.GetString(bytes);

                bytesr = new byte[4];
                reader.Read(bytesr, 0, 4);
                var size = BitConverter.ToInt32(bytesr);
                obj.key = new byte[size];
                reader.Read(obj.key, 0, size);
            }

            public override void Serialize(ref StoreKey obj)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(obj.tableType);
                var len = BitConverter.GetBytes(bytes.Length);
                writer.Write(len);
                writer.Write(bytes);

                len = BitConverter.GetBytes(obj.key.Length);
                writer.Write(len);
                writer.Write(obj.key);
            }
        }

        public class StoreValue
        {
            public byte[] value;
            public StoreValue()
            {
            }
        }

        public class StoreValueSerializer : BinaryObjectSerializer<StoreValue>
        {
            public override void Deserialize(ref StoreValue obj)
            {
                var bytesr = new byte[4];
                reader.Read(bytesr, 0, 4);
                int size = BitConverter.ToInt32(bytesr);
                obj.value = reader.ReadBytes(size);
            }

            public override void Serialize(ref StoreValue obj)
            {
                var len = BitConverter.GetBytes(obj.value.Length);
                writer.Write(len);
                writer.Write(obj.value);
            }
        }

        public class StoreInput
        {
            public byte[] value;
        }

        public class StoreOutput
        {
            public StoreValue value;
        }

        public class StoreContext
        {
            private Status status;
            private StoreOutput output;

            internal void Populate(ref Status status, ref StoreOutput output)
            {
                this.status = status;
                this.output = output;
            }

            internal void FinalizeRead(ref Status status, ref StoreOutput output)
            {
                status = this.status;
                output = this.output;
            }
        }

        public class StoreFunctions : IFunctions<StoreKey, StoreValue, StoreInput, StoreOutput, StoreContext>
        {
            public void RMWCompletionCallback(ref StoreKey key, ref StoreInput input, StoreContext ctx, Status status)
            {
            }

            public void ReadCompletionCallback(ref StoreKey key, ref StoreInput input, ref StoreOutput output, StoreContext ctx, Status status)
            {
                ctx.Populate(ref status, ref output);
            }


            public void UpsertCompletionCallback(ref StoreKey key, ref StoreValue value, StoreContext ctx)
            {
            }

            public void DeleteCompletionCallback(ref StoreKey key, StoreContext ctx)
            {
            }

            public void CopyUpdater(ref StoreKey key, ref StoreInput input, ref StoreValue oldValue, ref StoreValue newValue)
            {
            }

            public void InitialUpdater(ref StoreKey key, ref StoreInput input, ref StoreValue value)
            {
            }

            public bool InPlaceUpdater(ref StoreKey key, ref StoreInput input, ref StoreValue value)
            {
                if (value.value.Length < input.value.Length)
                    return false;

                value.value = input.value;
                return true;
            }

            public void SingleReader(ref StoreKey key, ref StoreInput input, ref StoreValue value, ref StoreOutput dst)
            {
                dst.value = value;
            }

            public void ConcurrentReader(ref StoreKey key, ref StoreInput input, ref StoreValue value, ref StoreOutput dst)
            {
                dst.value = value;
            }

            public bool ConcurrentWriter(ref StoreKey key, ref StoreValue src, ref StoreValue dst)
            {
                if (src == null)
                    return false;

                if (dst.value.Length != src.value.Length)
                    return false;

                dst = src;
                return true;
            }

            public void CheckpointCompletionCallback(string sessionId, CommitPoint commitPoint)
            {
            }

            public void SingleWriter(ref StoreKey key, ref StoreValue src, ref StoreValue dst)
            {
                dst = src;
            }
        }
    }
}

