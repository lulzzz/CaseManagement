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
    public class AddHumanTaskDefStartDeadLineCommandHandler : IRequestHandler<AddHumanTaskDefStartDeadLineCommand, string>
    {
        private readonly ILogger<AddHumanTaskDefStartDeadLineCommandHandler> _logger;
        private readonly IHumanTaskDefQueryRepository _humanTaskDefQueryRepository;
        private readonly IHumanTaskDefCommandRepository _humanTaskDefCommandRepository;

        public AddHumanTaskDefStartDeadLineCommandHandler(ILogger<AddHumanTaskDefStartDeadLineCommandHandler> logger, IHumanTaskDefQueryRepository humanTaskDefQueryRepository, IHumanTaskDefCommandRepository humanTaskDefCommandRepository)
        {
            _logger = logger;
            _humanTaskDefQueryRepository = humanTaskDefQueryRepository;
            _humanTaskDefCommandRepository = humanTaskDefCommandRepository;
        }

        public async Task<string> Handle(AddHumanTaskDefStartDeadLineCommand request, CancellationToken cancellationToken)
        {
            if (request.DeadLine == null)
            {
                _logger.LogError("the parameter 'deadLine' is missing");
                throw new BadRequestException(string.Format(Global.MissingParameter, "deadLine"));
            }

            var result = await _humanTaskDefQueryRepository.Get(request.Id, cancellationToken);
            if (result == null)
            {
                _logger.LogError($"The human task definition '{request.Id}' doesn't exist");
                throw new UnknownHumanTaskDefException(string.Format(Global.UnknownHumanTaskDef, request.Id));
            }

            var id = result.AddStartDeadLine(request.DeadLine.ToDomain());
            await _humanTaskDefCommandRepository.Update(result, cancellationToken);
            await _humanTaskDefCommandRepository.SaveChanges(cancellationToken);
            _logger.LogInformation($"Human task definition '{result.Name}', start deadline '{request.DeadLine.Name}' has been added");
            return id;
        }
    }
}
