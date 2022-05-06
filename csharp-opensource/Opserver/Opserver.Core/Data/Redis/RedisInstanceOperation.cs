﻿using System;
using System.Threading.Tasks;

namespace StackExchange.Opserver.Data.Redis
{
    public class RedisInstanceOperation
    {
        public RedisInstance Instance { get; set; }
        public InstanceCommandType Command { get; set; }
        public RedisInstance NewMaster { get; set; }

        public Task PerformAsync()
        {
            switch (Command)
            {
                case InstanceCommandType.MakeMaster:
                    var result = Instance.PromoteToMaster();
                    return Task.FromResult(result);
                case InstanceCommandType.SlaveTo:
                    return Instance.SlaveToAsync(NewMaster.HostAndPort);
                default:
                    throw new ArgumentOutOfRangeException(nameof(InstanceCommandType));
            }
        }

        public static RedisInstanceOperation FromString(string s)
        {
            var parts = s.Split(StringSplits.VerticalBar);
            if (parts.Length > 1 && Enum.TryParse<InstanceCommandType>(parts[0], out var opType))
            {
                var opee = RedisModule.Instances.Find(i => i.UniqueKey == parts[1]);
                switch (opType)
                {
                    case InstanceCommandType.MakeMaster:
                        return MakeMaster(opee);
                    case InstanceCommandType.SlaveTo:
                        var newMaster = RedisModule.Instances.Find(i => i.UniqueKey == parts[2]);
                        return SlaveTo(opee, newMaster);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(InstanceCommandType));
                }
            }
            throw new ArgumentOutOfRangeException(nameof(s), $"Invalid op string provided: '{s}'");
        }

        public override string ToString()
        {
            switch (Command)
            {
                case InstanceCommandType.MakeMaster:
                    return $"{InstanceCommandType.MakeMaster}|{Instance.UniqueKey}";
                case InstanceCommandType.SlaveTo:
                    return $"{InstanceCommandType.SlaveTo}|{Instance.UniqueKey}|{NewMaster.UniqueKey}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(InstanceCommandType));
            }
        }

        public static RedisInstanceOperation MakeMaster(RedisInstance instance) =>
            new RedisInstanceOperation
            {
                Command = InstanceCommandType.MakeMaster,
                Instance = instance
            };

        public static RedisInstanceOperation SlaveTo(RedisInstance instance, RedisInstance newMaster) =>
            new RedisInstanceOperation
            {
                Command = InstanceCommandType.SlaveTo,
                Instance = instance,
                NewMaster = newMaster
            };
    }

    public enum InstanceCommandType
    {
        MakeMaster,
        SlaveTo
    }
}
