﻿using CaseManagement.Gateway.Website.CasePlanInstance.DTOs;
using CaseManagement.Gateway.Website.CasePlanInstance.Queries;
using System.Threading.Tasks;

namespace CaseManagement.Gateway.Website.CasePlanInstance.QueryHandlers
{
    public interface ISearchCasePlanInstanceQueryHandler
    {
        Task<FindResponse<CasePlanInstanceResponse>> Handle(SearchCasePlanInstanceQuery searchCasePlanInstanceQuery);
    }
}