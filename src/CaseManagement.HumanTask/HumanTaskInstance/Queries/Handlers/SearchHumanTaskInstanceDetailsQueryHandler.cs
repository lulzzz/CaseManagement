﻿using CaseManagement.Common.Results;
using CaseManagement.HumanTask.Authorization;
using CaseManagement.HumanTask.Domains;
using CaseManagement.HumanTask.Exceptions;
using CaseManagement.HumanTask.HumanTaskInstance.Queries.Results;
using CaseManagement.HumanTask.Localization;
using CaseManagement.HumanTask.Persistence;
using CaseManagement.HumanTask.Persistence.Parameters;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.HumanTask.HumanTaskInstance.Queries.Handlers
{
    public class SearchHumanTaskInstanceDetailsQueryHandler : IRequestHandler<SearchHumanTaskInstanceDetailsQuery, SearchResult<TaskInstanceDetailsResult>>
    {
        private readonly ILogger<SearchHumanTaskInstanceDetailsQueryHandler> _logger;
        private readonly IAuthorizationHelper _authorizationHelper;
        private readonly ITranslationHelper _translationHelper;
        private readonly IHumanTaskInstanceQueryRepository _humanTaskInstanceQueryRepository;

        public SearchHumanTaskInstanceDetailsQueryHandler(
            ILogger<SearchHumanTaskInstanceDetailsQueryHandler> logger,
            IAuthorizationHelper authorizationHelper,
            ITranslationHelper translationHelper,
            IHumanTaskInstanceQueryRepository humanTaskInstanceQueryRepository)
        {
            _logger = logger;
            _authorizationHelper = authorizationHelper;
            _translationHelper = translationHelper;
            _humanTaskInstanceQueryRepository = humanTaskInstanceQueryRepository;
        }

        public async Task<SearchResult<TaskInstanceDetailsResult>> Handle(SearchHumanTaskInstanceDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Search human task instance");
            var nameIdentifier = _authorizationHelper.GetNameIdentifier(request.Claims);
            var roles = _authorizationHelper.GetRoles(request.Claims);
            var result = await _humanTaskInstanceQueryRepository.Search(new SearchHumanTaskInstanceParameter
            {
                UserIdentifier = nameIdentifier,
                GroupNames = roles,
                Count = request.Count,
                Order = request.Order,
                OrderBy = request.OrderBy,
                StartIndex = request.StartIndex,
                StatusLst = request.StatusLst,
                ActualOwner = request.ActualOwner                
            }, cancellationToken);
            var content = new List<TaskInstanceDetailsResult>();
            foreach(var record in result.Content)
            {
                var callbackTxt = new Func<ICollection<PresentationElementInstance>, Localization.Translation>((t) =>
                {
                    if (t == null || !t.Any())
                    {
                        return null;
                    }

                    try
                    {
                        return _translationHelper.Translate(t);
                    }
                    catch (BadOperationExceptions) { return null; }
                });
                var appRoles = await _authorizationHelper.GetRoles(record, request.Claims, cancellationToken);
                var name = callbackTxt(record.Names);
                var subject = callbackTxt(record.Subjects);
                content.Add(TaskInstanceDetailsResult.ToDto(record, name, subject, appRoles, _authorizationHelper.GetNameIdentifier(request.Claims)));
            }

            return new SearchResult<TaskInstanceDetailsResult>
            {
                Count = result.Count,
                TotalLength = result.TotalLength,
                StartIndex = result.StartIndex,
                Content = content
            };
        }
    }
}
