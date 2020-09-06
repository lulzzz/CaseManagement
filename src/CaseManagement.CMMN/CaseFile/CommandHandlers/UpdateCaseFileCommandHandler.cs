﻿using CaseManagement.CMMN.CaseFile.Commands;
using CaseManagement.CMMN.CaseFile.Exceptions;
using CaseManagement.CMMN.Domains;
using CaseManagement.CMMN.Infrastructures;
using CaseManagement.CMMN.Infrastructures.EvtStore;
using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.CaseFile.CommandHandlers
{
    public class UpdateCaseFileCommandHandler : IUpdateCaseFileCommandHandler
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ICommitAggregateHelper _commitAggregateHelper;

        public UpdateCaseFileCommandHandler(IEventStoreRepository eventStoreRepository, ICommitAggregateHelper commitAggregateHelper)
        {
            _eventStoreRepository = eventStoreRepository;
            _commitAggregateHelper = commitAggregateHelper;
        }

        public async Task<bool> Handle(UpdateCaseFileCommand command, CancellationToken token)
        {
            var caseFile = await _eventStoreRepository.GetLastAggregate<CaseFileAggregate>(command.Id, CaseFileAggregate.GetStreamName(command.Id), token);
            if (caseFile == null || string.IsNullOrWhiteSpace(caseFile.Id))
            {
                throw new UnknownCaseFileException(command.Id);
            }

            caseFile.Update(command.Name, command.Description, command.Payload);
            await _commitAggregateHelper.Commit(caseFile, CaseFileAggregate.GetStreamName(caseFile.Id), token);
            return true;
        }
    }
}
