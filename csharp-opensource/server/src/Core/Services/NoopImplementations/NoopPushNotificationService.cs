﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Enums;
using Bit.Core.Models.Table;

namespace Bit.Core.Services
{
    public class NoopPushNotificationService : IPushNotificationService
    {
        public Task PushSyncCipherCreateAsync(Cipher cipher, IEnumerable<Guid> collectionIds)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncCipherDeleteAsync(Cipher cipher)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncCiphersAsync(Guid userId)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncCipherUpdateAsync(Cipher cipher, IEnumerable<Guid> collectionIds)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncFolderCreateAsync(Folder folder)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncFolderDeleteAsync(Folder folder)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncFolderUpdateAsync(Folder folder)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncOrgKeysAsync(Guid userId)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncSettingsAsync(Guid userId)
        {
            return Task.FromResult(0);
        }

        public Task PushSyncVaultAsync(Guid userId)
        {
            return Task.FromResult(0);
        }

        public Task PushLogOutAsync(Guid userId)
        {
            return Task.FromResult(0);
        }

        public Task SendPayloadToOrganizationAsync(string orgId, PushType type, object payload, string identifier,
            string deviceId = null)
        {
            return Task.FromResult(0);
        }

        public Task SendPayloadToUserAsync(string userId, PushType type, object payload, string identifier,
            string deviceId = null)
        {
            return Task.FromResult(0);
        }
    }
}
