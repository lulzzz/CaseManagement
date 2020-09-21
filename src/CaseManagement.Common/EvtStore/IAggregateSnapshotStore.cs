﻿using CaseManagement.Common.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Common.EvtStore
{
    public interface IAggregateSnapshotStore
    {
        Task<SnapshotElement<T>> GetLast<T>(string id) where T : BaseAggregate;
        Task<bool> Add(SnapshotElement<BaseAggregate> snapshot);
        ICollection<SnapshotElement<T>> Query<T>() where T : BaseAggregate;
    }
}
