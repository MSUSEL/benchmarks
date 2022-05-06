﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Models.Table;

namespace Bit.Core.Repositories
{
    public interface IDeviceRepository : IRepository<Device, Guid>
    {
        Task<Device> GetByIdAsync(Guid id, Guid userId);
        Task<Device> GetByIdentifierAsync(string identifier);
        Task<Device> GetByIdentifierAsync(string identifier, Guid userId);
        Task<ICollection<Device>> GetManyByUserIdAsync(Guid userId);
        Task ClearPushTokenAsync(Guid id);
    }
}
