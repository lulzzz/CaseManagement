﻿using CaseManagement.CMMN.CaseInstance.Commands;
using CaseManagement.CMMN.CaseInstance.Exceptions;
using CaseManagement.CMMN.Domains;
using CaseManagement.CMMN.Infrastructures.Bus;
using CaseManagement.CMMN.Infrastructures.EvtStore;
using CaseManagement.Workflow.Infrastructure.Bus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.CaseInstance.CommandHandlers
{
    public class CloseCommandHandler : ICloseCommandHandler
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IQueueProvider _queueProvider;

        public CloseCommandHandler(IEventStoreRepository eventStoreRepository, IQueueProvider queueProvider)
        {
            _eventStoreRepository = eventStoreRepository;
            _queueProvider = queueProvider;
        }

        public async Task Handle(CloseCommand closeCommand)
        {
            var caseInstance = await _eventStoreRepository.GetLastAggregate<Domains.CaseInstance>(closeCommand.CaseInstanceId, Domains.CaseInstance.GetStreamName(closeCommand.CaseInstanceId));
            if (caseInstance == null || string.IsNullOrWhiteSpace(caseInstance.Id))
            {
                throw new UnknownCaseInstanceException(closeCommand.CaseInstanceId);
            }

            if (caseInstance.State == Enum.GetName(typeof(CaseStates), CaseStates.Suspended))
            {
                caseInstance.MakeTransition(CMMNTransitions.Close);
                await _queueProvider.QueueTransition(caseInstance.Id, null, CMMNTransitions.Close);
            }
            else
            {
                caseInstance.MakeTransition(CMMNTransitions.Close);
                await _queueProvider.QueueEvent(caseInstance.DomainEvents.Last());
            }
        }
    }
}