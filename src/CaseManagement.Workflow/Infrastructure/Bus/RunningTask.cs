﻿using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.Workflow.Infrastructure.Bus
{
    public class RunningTask
    {
        public RunningTask(string processId, Task task, BaseAggregate aggregagate, CancellationTokenSource cancellationTokenSource)
        {
            ProcessId = processId;
            Task = task;
            CancellationTokenSource = cancellationTokenSource;
            Aggregate = aggregagate;
        }

        public string ProcessId { get; set; }
        public Task Task { get; set; }
        public BaseAggregate Aggregate { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
    }
}
