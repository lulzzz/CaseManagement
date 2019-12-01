﻿using CaseManagement.CMMN.CaseProcess.Commands;
using CaseManagement.CMMN.CaseProcess.ProcessHandlers;
using CaseManagement.CMMN.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.CaseProcess.CommandHandlers
{
    public class CaseLaunchProcessCommandHandler : ICaseLaunchProcessCommandHandler
    {
        private readonly IProcessQueryRepository _cmmnProcessQueryRepository;
        private readonly IEnumerable<ICaseProcessHandler> _processHandlers;

        public CaseLaunchProcessCommandHandler(IProcessQueryRepository cmmnProcessQueryRepository, IEnumerable<ICaseProcessHandler> processHandlers)
        {
            _cmmnProcessQueryRepository = cmmnProcessQueryRepository;
            _processHandlers = processHandlers;
        }

        public async Task<CaseProcessResponse> Handle(LaunchCaseProcessCommand launchCaseProcessCommand)
        {
            var process = await _cmmnProcessQueryRepository.FindById(launchCaseProcessCommand.Id);
            if (process == null)
            {
                // TODO : THROW EXCEPTION.
            }

            var processHandler = _processHandlers.FirstOrDefault(p => p.ImplementationType == process.ImplementationType);
            if (processHandler == null)
            {
                // TODO : THROW EXCEPTION.
            }

            var result = await processHandler.Handle(process, new CaseProcessParameter(launchCaseProcessCommand.Parameters));
            return result;
        }
    }
}
