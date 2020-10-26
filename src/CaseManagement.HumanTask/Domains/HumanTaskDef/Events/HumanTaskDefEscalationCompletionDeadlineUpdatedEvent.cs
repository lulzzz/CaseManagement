﻿using CaseManagement.Common.Domains;
using System;
using System.Diagnostics;

namespace CaseManagement.HumanTask.Domains.HumanTaskDef.Events
{
    [DebuggerDisplay("Update escalation completion deadline")]
    public class HumanTaskDefEscalationCompletionDeadlineUpdatedEvent : DomainEvent
    {
        public HumanTaskDefEscalationCompletionDeadlineUpdatedEvent(string id, string aggregateId, int version, string completionDeadLineId, string escalationId, Escalation escalation, DateTime updateDateTime) : base(id, aggregateId, version)
        {
            CompletionDeadLineId = completionDeadLineId;
            EscalationId = escalationId;
            Escalation = escalation;
            UpdateDateTime = updateDateTime;
        }

        public string CompletionDeadLineId { get; set; }
        public string EscalationId { get; set; }
        public Escalation Escalation { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}