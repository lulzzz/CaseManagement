﻿using CaseManagement.Common.Domains;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CaseManagement.CMMN.Domains
{
    [DebuggerDisplay("Make transition '{Transition}' to element '{ElementId}'")]
    [Serializable]
    public class CaseElementTransitionRaisedEvent : DomainEvent
    {
        public CaseElementTransitionRaisedEvent(string id, string aggregateId, int version, string elementId, CMMNTransitions transition, string message, Dictionary<string, string> incomingTokens, DateTime updateDateTime) : base(id, aggregateId, version)
        {
            ElementId = elementId;
            Transition = transition;
            Message = message;
            IncomingTokens = incomingTokens;
            UpdateDateTime = updateDateTime;
        }

        public string ElementId { get; set; }
        public CMMNTransitions Transition { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> IncomingTokens { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
