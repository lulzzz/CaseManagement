﻿using CaseManagement.CMMN.Domains;
using CaseManagement.CMMN.Parser;
using CaseManagement.CMMN.Persistence;
using CaseManagement.CMMN.Persistence.InMemory;
using CaseManagement.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CaseManagement.CMMN
{
    public class ServerBuilder
    {
        private IServiceCollection _services;

        public ServerBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public ServerBuilder AddDefinitions(List<string> pathLst)
        {
            var builder = _services.BuildServiceProvider();
            var commitAggregateHelper = (ICommitAggregateHelper)builder.GetService(typeof(ICommitAggregateHelper));
            var caseFiles = new ConcurrentBag<CaseFileAggregate>();
            var caseDefinitions = new ConcurrentBag<CasePlanAggregate>();
            foreach(var path in pathLst)
            {
                var cmmnTxt = File.ReadAllText(path);
                var name = Path.GetFileName(path);
                var caseFile = CaseFileAggregate.New(name, name, 0, cmmnTxt);
                var tDefinitions = CMMNParser.ParseWSDL(cmmnTxt);
                var caseDefinition = CMMNParser.ExtractCasePlans(tDefinitions, caseFile);
                foreach(var cd in caseDefinition)
                {
                    caseDefinitions.Add(cd);
                }

                caseFiles.Add(caseFile);
                var newCaseFile = caseFile.Publish();
                caseFiles.Add(newCaseFile);
                commitAggregateHelper.Commit(caseFile, CaseFileAggregate.GetStreamName(caseFile.AggregateId), CancellationToken.None).Wait();
                commitAggregateHelper.Commit(newCaseFile, CaseFileAggregate.GetStreamName(newCaseFile.AggregateId), CancellationToken.None).Wait();
            }

            _services.TryUpdateSingleton<ICaseFileQueryRepository>(new InMemoryCaseFileQueryRepository(caseFiles));
            _services.TryUpdateSingleton<ICaseFileCommandRepository>(new InMemoryCaseFileCommandRepository(caseFiles));
            _services.TryUpdateSingleton<ICasePlanCommandRepository>(new InMemoryCasePlanCommandRepository(caseDefinitions));
            _services.TryUpdateSingleton<ICasePlanQueryRepository>(new InMemoryCasePlanQueryRepository(caseDefinitions));
            return this;
        }

        public ServerBuilder SetCasePlanInstance(CasePlanInstanceAggregate casePlanInstance)
        {
            var casePlanInstances = new ConcurrentBag<CasePlanInstanceAggregate>
            {
                casePlanInstance
            };
            _services.TryUpdateSingleton<ICasePlanInstanceCommandRepository>(new InMemoryCaseInstanceCommandRepository(casePlanInstances));
            _services.TryUpdateSingleton<ICasePlanInstanceQueryRepository>(new InMemoryCaseInstanceQueryRepository(casePlanInstances));
            return this;
        }
    }
}
