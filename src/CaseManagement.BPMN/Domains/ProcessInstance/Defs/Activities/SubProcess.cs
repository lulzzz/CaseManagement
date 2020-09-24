﻿using System.Linq;

namespace CaseManagement.BPMN.Domains
{
    public class SubProcess : BaseActivity
    {
        public SubProcess() : base() { }

        public override FlowNodeTypes FlowNode => FlowNodeTypes.SUBPROCESS;

        public override object Clone()
        {
            return new SubProcess
            {
                Id = Id,
                Name = Name,
                StartQuantity = StartQuantity
            };
        }
    }
}
