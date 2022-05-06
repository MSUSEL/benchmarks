﻿using System;
using System.Threading.Tasks;
using Bit.Core.Repositories;
using Bit.Core.Services;
using NSubstitute;
using Xunit;

namespace Bit.Core.Test.Services
{
    public class DeviceServiceTests
    {
        [Fact]
        public async Task DeviceSaveShouldUpdateRevisionDateAndPushRegistration()
        {
            var deviceRepo = Substitute.For<IDeviceRepository>();
            var pushRepo = Substitute.For<IPushRegistrationService>();
            var deviceService = new DeviceService(deviceRepo, pushRepo);

            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var device = new Models.Table.Device
            {
                Id = id,
                Name = "test device",
                Type = Enums.DeviceType.Android,
                UserId = userId,
                PushToken = "testtoken",
                Identifier = "testid"
            };
            await deviceService.SaveAsync(device);

            Assert.True(device.RevisionDate - DateTime.UtcNow < TimeSpan.FromSeconds(1));
            await pushRepo.Received().CreateOrUpdateRegistrationAsync("testtoken", id.ToString(),
                userId.ToString(), "testid", Enums.DeviceType.Android);
        }
    }
}
