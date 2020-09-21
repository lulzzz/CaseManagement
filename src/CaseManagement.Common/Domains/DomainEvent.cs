﻿namespace CaseManagement.Common.Domains
{
    public class DomainEvent
    {
        public DomainEvent(string id, string aggregateId, int version)
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
        }

        public string Id { get; set; }
        public string AggregateId { get; set; }
        public int Version { get; set; }
    }
}
