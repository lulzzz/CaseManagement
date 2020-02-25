﻿using CaseManagement.CMMN.Domains;
using CaseManagement.CMMN.Extensions;
using CaseManagement.CMMN.Persistence;
using CaseManagement.CMMN.Persistence.Parameters;
using CaseManagement.CMMN.Persistence.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.Performance
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IPerformanceQueryRepository _performanceQueryRepository;

        public PerformanceService(IPerformanceQueryRepository performanceQueryRepository)
        {
            _performanceQueryRepository = performanceQueryRepository;
        }

        public async Task<JArray> GetPerformances()
        {
            var result = await _performanceQueryRepository.GetMachineNames();
            return new JArray(result);
        }

        public async Task<JObject> SearchPerformances(IEnumerable<KeyValuePair<string, string>> query)
        {
            var result = await _performanceQueryRepository.FindPerformance(ExtractFindPerformanceParameter(query));
            return ToDto(result);
        }

        private static JObject ToDto(FindResponse<PerformanceAggregate> resp)
        {
            return new JObject
            {
                { "start_index", resp.StartIndex },
                { "total_length", resp.TotalLength },
                { "count", resp.Count },
                { "content", new JArray(resp.Content.Select(r => ToDto(r))) }
            };
        }

        private static JObject ToDto(PerformanceAggregate performanceStatistic)
        {
            return new JObject
            {
                { "datetime", performanceStatistic.CaptureDateTime },
                { "machine_name", performanceStatistic.MachineName },
                { "nb_working_threads", performanceStatistic.NbWorkingThreads },
                { "memory_consumed_mb", performanceStatistic.MemoryConsumedMB }
            };
        }

        private static FindPerformanceParameter ExtractFindPerformanceParameter(IEnumerable<KeyValuePair<string, string>> query)
        {
            string machineName;
            DateTime startDateTime;
            string groupBy;
            var parameter = new FindPerformanceParameter();
            parameter.ExtractFindParameter(query);
            if (query.TryGet("machine_name", out machineName))
            {
                parameter.MachineName = machineName;
            }

            if (query.TryGet("start_datetime", out startDateTime))
            {
                parameter.StartDateTime = startDateTime;
            }

            if (query.TryGet("group_by", out groupBy))
            {
                parameter.GroupBy = groupBy;
            }

            return parameter;
        }
    }
}
