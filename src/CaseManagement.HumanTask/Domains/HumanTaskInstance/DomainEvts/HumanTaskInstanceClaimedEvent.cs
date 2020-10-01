﻿using CaseManagement.Common.Domains;
using System;
using System.Diagnostics;

namespace CaseManagement.HumanTask.Domains
{
    [DebuggerDisplay("'{UserPrincipal}' claims the human task instance")]
    public class HumanTaskInstanceClaimedEvent : DomainEvent
    {
        public HumanTaskInstanceClaimedEvent(string id, string aggregateId, int version, string userPrincipal, DateTime executionDateTime) : base(id, aggregateId, version)
        {
            UserPrincipal = userPrincipal;
            ExecutionDateTime = executionDateTime;
        }

        public string UserPrincipal { get; set; }
        public DateTime ExecutionDateTime { get; set; }
    }
}
