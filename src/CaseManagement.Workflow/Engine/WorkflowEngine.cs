﻿using CaseManagement.Workflow.Domains;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Workflow.Engine
{
    public class WorkflowEngine : IWorkflowEngine
    {
        private readonly IProcessFlowElementProcessorFactory _processFlowElementProcessorFactory;

        public WorkflowEngine(IProcessFlowElementProcessorFactory processFlowElementProcessorFactory)
        {
            _processFlowElementProcessorFactory = processFlowElementProcessorFactory;
        }

        public async Task Start(ProcessFlowInstance processFlowInstance, ProcessFlowInstanceExecutionContext context)
        {
            var result = await Start(processFlowInstance, context, processFlowInstance.StartElement);
            processFlowInstance.Finish();
        }

        private async Task<bool> Start(ProcessFlowInstance processFlowInstance, ProcessFlowInstanceExecutionContext context, ProcessFlowInstanceElement elt)
        {
            var previousElts = processFlowInstance.PreviousElements(elt.Id);
            if (previousElts.Any(p => p.Status != ProcessFlowInstanceElementStatus.Finished))
            {
                return false;
            }

            if (elt.Status != ProcessFlowInstanceElementStatus.Finished)
            {
                var processor = _processFlowElementProcessorFactory.Build(elt);
                await processor.Handle(elt, context);
            }

            var nextElts = processFlowInstance.NextElements(elt.Id);
            bool result = true;
            foreach (var nextElt in nextElts)
            {
                if (!await Start(processFlowInstance, context, nextElt))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
