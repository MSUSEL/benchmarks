﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Models.Data;
using Bit.Core.Models.Table;

namespace Bit.Core.Repositories
{
    public interface IEventRepository
    {
        Task<PagedResult<IEvent>> GetManyByUserAsync(Guid userId, DateTime startDate, DateTime endDate,
            PageOptions pageOptions);
        Task<PagedResult<IEvent>> GetManyByOrganizationAsync(Guid organizationId, DateTime startDate, DateTime endDate,
            PageOptions pageOptions);
        Task<PagedResult<IEvent>> GetManyByOrganizationActingUserAsync(Guid organizationId, Guid actingUserId,
            DateTime startDate, DateTime endDate, PageOptions pageOptions);
        Task<PagedResult<IEvent>> GetManyByCipherAsync(Cipher cipher, DateTime startDate, DateTime endDate,
            PageOptions pageOptions);
        Task CreateAsync(IEvent e);
        Task CreateManyAsync(IList<IEvent> e);
    }
}
