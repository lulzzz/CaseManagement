﻿using CaseManagement.Common.Exceptions;
using CaseManagement.HumanTask.Exceptions;
using CaseManagement.HumanTask.Persistence;
using CaseManagement.HumanTask.Resources;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.HumanTask.HumanTaskDef.Commands.Handlers
{
    public class AddCallbackOperationCommandHandler : IRequestHandler<AddCallbackOperationCommand, string>
    {
        private readonly ILogger<AddCallbackOperationCommandHandler> _logger;
        private readonly IHumanTaskDefQueryRepository _humanTaskDefQueryRepository;
        private readonly IHumanTaskDefCommandRepository _humanTaskDefCommandRepository;

        public AddCallbackOperationCommandHandler(
            ILogger<AddCallbackOperationCommandHandler> logger,
            IHumanTaskDefQueryRepository humanTaskDefQueryRepository, 
            IHumanTaskDefCommandRepository humanTaskDefCommandRepository)
        {
            _logger = logger;
            _humanTaskDefQueryRepository = humanTaskDefQueryRepository;
            _humanTaskDefCommandRepository = humanTaskDefCommandRepository;
        }

        public async Task<string> Handle(AddCallbackOperationCommand request, CancellationToken cancellationToken)
        {
            if (request.Operation == null)
            {
                _logger.LogError("the parameter 'operation' is missing");
                throw new BadRequestException(string.Format(Global.MissingParameter, "operation"));
            }

            var result = await _humanTaskDefQueryRepository.Get(request.HumanTaskDefId, cancellationToken);
            if (result == null)
            {
                _logger.LogError($"The human task definition '{request.HumanTaskDefId}' doesn't exist");
                throw new UnknownHumanTaskDefException(string.Format(Global.UnknownHumanTaskDef, request.HumanTaskDefId));
            }

            var id = result.AddCallbackOperation(request.Operation.ToDomain());
            await _humanTaskDefCommandRepository.Update(result, cancellationToken);
            await _humanTaskDefCommandRepository.SaveChanges(cancellationToken);
            _logger.LogInformation($"Human task definition '{result.Name}', callback operation has been added");
            return id;
        }
    }
}
