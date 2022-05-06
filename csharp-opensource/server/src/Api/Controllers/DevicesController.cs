﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bit.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Bit.Core.Models.Api;
using Bit.Core.Exceptions;
using Bit.Core.Models.Table;
using Bit.Core.Services;

namespace Bit.Api.Controllers
{
    [Route("devices")]
    [Authorize("Application")]
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDeviceService _deviceService;
        private readonly IUserService _userService;

        public DevicesController(
            IDeviceRepository deviceRepository,
            IDeviceService deviceService,
            IUserService userService)
        {
            _deviceRepository = deviceRepository;
            _deviceService = deviceService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<DeviceResponseModel> Get(string id)
        {
            var device = await _deviceRepository.GetByIdAsync(new Guid(id), _userService.GetProperUserId(User).Value);
            if (device == null)
            {
                throw new NotFoundException();
            }

            var response = new DeviceResponseModel(device);
            return response;
        }

        [HttpGet("identifier/{identifier}")]
        public async Task<DeviceResponseModel> GetByIdentifier(string identifier)
        {
            var device = await _deviceRepository.GetByIdentifierAsync(identifier, _userService.GetProperUserId(User).Value);
            if (device == null)
            {
                throw new NotFoundException();
            }

            var response = new DeviceResponseModel(device);
            return response;
        }

        [HttpGet("")]
        public async Task<ListResponseModel<DeviceResponseModel>> Get()
        {
            ICollection<Device> devices = await _deviceRepository.GetManyByUserIdAsync(_userService.GetProperUserId(User).Value);
            var responses = devices.Select(d => new DeviceResponseModel(d));
            return new ListResponseModel<DeviceResponseModel>(responses);
        }

        [HttpPost("")]
        public async Task<DeviceResponseModel> Post([FromBody]DeviceRequestModel model)
        {
            var device = model.ToDevice(_userService.GetProperUserId(User));
            await _deviceService.SaveAsync(device);

            var response = new DeviceResponseModel(device);
            return response;
        }

        [HttpPut("{id}")]
        [HttpPost("{id}")]
        public async Task<DeviceResponseModel> Put(string id, [FromBody]DeviceRequestModel model)
        {
            var device = await _deviceRepository.GetByIdAsync(new Guid(id), _userService.GetProperUserId(User).Value);
            if (device == null)
            {
                throw new NotFoundException();
            }

            await _deviceService.SaveAsync(model.ToDevice(device));

            var response = new DeviceResponseModel(device);
            return response;
        }

        [HttpPut("identifier/{identifier}/token")]
        [HttpPost("identifier/{identifier}/token")]
        public async Task PutToken(string identifier, [FromBody]DeviceTokenRequestModel model)
        {
            var device = await _deviceRepository.GetByIdentifierAsync(identifier, _userService.GetProperUserId(User).Value);
            if (device == null)
            {
                throw new NotFoundException();
            }

            await _deviceService.SaveAsync(model.ToDevice(device));
        }

        [AllowAnonymous]
        [HttpPut("identifier/{identifier}/clear-token")]
        [HttpPost("identifier/{identifier}/clear-token")]
        public async Task PutClearToken(string identifier)
        {
            var device = await _deviceRepository.GetByIdentifierAsync(identifier);
            if (device == null)
            {
                throw new NotFoundException();
            }

            await _deviceService.ClearTokenAsync(device);
        }

        [HttpDelete("{id}")]
        [HttpPost("{id}/delete")]
        public async Task Delete(string id)
        {
            var device = await _deviceRepository.GetByIdAsync(new Guid(id), _userService.GetProperUserId(User).Value);
            if (device == null)
            {
                throw new NotFoundException();
            }

            await _deviceService.DeleteAsync(device);
        }
    }
}
