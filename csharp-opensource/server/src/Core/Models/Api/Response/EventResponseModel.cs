﻿using System;
using Bit.Core.Enums;
using Bit.Core.Models.Data;

namespace Bit.Core.Models.Api
{
    public class EventResponseModel : ResponseModel
    {
        public EventResponseModel(IEvent ev)
            : base("event")
        {
            if (ev == null)
            {
                throw new ArgumentNullException(nameof(ev));
            }

            Type = ev.Type;
            UserId = ev.UserId;
            OrganizationId = ev.OrganizationId;
            CipherId = ev.CipherId;
            CollectionId = ev.CollectionId;
            GroupId = ev.GroupId;
            PolicyId = ev.PolicyId;
            OrganizationUserId = ev.OrganizationUserId;
            ActingUserId = ev.ActingUserId;
            Date = ev.Date;
            DeviceType = ev.DeviceType;
            IpAddress = ev.IpAddress;
        }

        public EventType Type { get; set; }
        public Guid? UserId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? CipherId { get; set; }
        public Guid? CollectionId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? PolicyId { get; set; }
        public Guid? OrganizationUserId { get; set; }
        public Guid? ActingUserId { get; set; }
        public DateTime Date { get; set; }
        public DeviceType? DeviceType { get; set; }
        public string IpAddress { get; set; }
    }
}
