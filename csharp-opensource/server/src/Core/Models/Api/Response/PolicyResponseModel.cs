﻿using System;
using System.Collections.Generic;
using Bit.Core.Enums;
using Bit.Core.Models.Table;
using Newtonsoft.Json;

namespace Bit.Core.Models.Api
{
    public class PolicyResponseModel : ResponseModel
    {
        public PolicyResponseModel(Policy policy, string obj = "policy")
            : base(obj)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            Id = policy.Id.ToString();
            OrganizationId = policy.OrganizationId.ToString();
            Type = policy.Type;
            Enabled = policy.Enabled;
            if (!string.IsNullOrWhiteSpace(policy.Data))
            {
                Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(policy.Data);
            }
        }

        public string Id { get; set; }
        public string OrganizationId { get; set; }
        public PolicyType Type { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public bool Enabled { get; set; }
    }
}
