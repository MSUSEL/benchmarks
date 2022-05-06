﻿using System;
using Bit.Core.Enums;

namespace Bit.Core.Models.Data
{
    public class EventMessage : IEvent
    {
        public EventMessage() { }

        public EventMessage(CurrentContext currentContext)
            : base()
        {
            IpAddress = currentContext.IpAddress;
            DeviceType = currentContext.DeviceType;
        }

        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public Guid? UserId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? CipherId { get; set; }
        public Guid? CollectionId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? PolicyId { get; set; }
        public Guid? OrganizationUserId { get; set; }
        public Guid? ActingUserId { get; set; }
        public DeviceType? DeviceType { get; set; }
        public string IpAddress { get; set; }
        public Guid? IdempotencyId { get; private set; } = Guid.NewGuid();
    }
}
