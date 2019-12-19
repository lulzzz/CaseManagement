﻿using CaseManagement.CMMN.Infrastructures.Bus.LaunchProcess;
using CaseManagement.Workflow.Infrastructure.Bus.RaiseDomainEvent;
using CaseManagement.Workflow.Infrastructure.Bus.StopProcess;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CaseManagement.Workflow.Infrastructure.Bus
{
    public static class QueueProviderExtensions
    {
        public static Task QueueRaiseEvent(this IQueueProvider queueProvider, string processId, DomainEvent domainEvent)
        {
            var message = new RaiseDomainEventMessage(processId, domainEvent.GetType().AssemblyQualifiedName, JsonConvert.SerializeObject(domainEvent));
            return queueProvider.Queue(RaiseDomainEventMessageConsumer.QUEUE_NAME, JsonConvert.SerializeObject(message));
        }

        public static Task QueueLaunchProcess(this IQueueProvider queueProvider, string processId)
        {
            var message = new LaunchProcessMessage(processId);
            return queueProvider.Queue(CMMNLaunchProcessMessageConsumer.QUEUE_NAME, JsonConvert.SerializeObject(message));
        }

        public static Task QueueStopProcess(this IQueueProvider queueProvider, string processId)
        {
            var message = new StopProcessMessage(processId);
            return queueProvider.Queue(StopProcessMessageConsumer.QUEUE_NAME, JsonConvert.SerializeObject(message));
        }
    }
}
