﻿using CaseManagement.CMMN.CasePlanInstance.Exceptions;
using CaseManagement.CMMN.CasePlanInstance.Processors.Handlers;
using CaseManagement.CMMN.Domains;
using CaseManagement.CMMN.Infrastructure.ExternalEvts;
using CaseManagement.CMMN.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.CasePlanInstance.Processors
{
    public class HumanTaskProcessor : BaseTaskOrStageProcessor<HumanTaskElementInstance>
    {
        private readonly IEnumerable<IHumanTaskHandler> _humanTaskHandlers;

        public HumanTaskProcessor(ISubscriberRepository subscriberRepository, IEnumerable<IHumanTaskHandler> humanTaskHandlers) : base(subscriberRepository) 
        {
            _humanTaskHandlers = humanTaskHandlers;
        }

        protected override async Task ProtectedProcess(CMMNExecutionContext executionContext, HumanTaskElementInstance elt, CancellationToken cancellationToken)
        {
            var handler = _humanTaskHandlers.FirstOrDefault(_ => _.Implementation == elt.Implemention);
            if (handler == null)
            {
                throw new CMMNProcessorException(Global.UnknownHumanTaskImplementation);
            }

            if (!executionContext.Instance.WorkerTaskExists(elt.Id))
            {
                var workerTaskId = await handler.Create(executionContext, elt, cancellationToken);
                executionContext.Instance.TryAddWorkerTask(elt.Id, workerTaskId);
            }

            var completeSubscription = await TrySubscribe(executionContext, elt, CMMNConstants.ExternalTransitionNames.Complete, cancellationToken);
            if (completeSubscription.IsCaptured)
            {
                executionContext.Instance.MakeTransition(elt, CMMNTransitions.Complete);
            }
        }
    }
}
