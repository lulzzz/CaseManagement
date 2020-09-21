﻿using CaseManagement.Common.Domains;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CaseManagement.CMMN.Domains
{
    [Serializable]
    [DebuggerDisplay("case plan instance is created")]
    public class CasePlanInstanceCreatedEvent : DomainEvent
    {
        public CasePlanInstanceCreatedEvent(string id, string aggregateId, int version, string caseOwner, ICollection<CasePlanInstanceRole> roles, ICollection<CasePlanInstanceRole> permissions, string jsonContent, DateTime createDateTime, string casePlanId, string casePlanName, Dictionary<string, string> parameters, ICollection<CaseFileItemInstance> files) : base(id, aggregateId, version)
        {
            CaseOwner = caseOwner;
            Roles = roles;
            Permissions = permissions;
            JsonContent = jsonContent;
            CreateDateTime = createDateTime;
            CasePlanId = casePlanId;
            CasePlanName = casePlanName;
            Parameters = parameters;
            Files = files;
        }

        public string CaseOwner { get; set; }
        public ICollection<CasePlanInstanceRole> Roles { get; set; }
        public ICollection<CasePlanInstanceRole> Permissions { get; set; }
        public string JsonContent { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CasePlanId { get; set; }
        public string CasePlanName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public ICollection<CaseFileItemInstance> Files { get; set; }
    }
}