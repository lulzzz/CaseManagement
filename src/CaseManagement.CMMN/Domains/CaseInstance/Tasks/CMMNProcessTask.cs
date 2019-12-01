﻿using System.Collections.Generic;

namespace CaseManagement.CMMN.Domains
{
    public class CMMNProcessTask : CMMNTask
    {
        public CMMNProcessTask(string name) : base(name)
        {
            Mappings = new List<CMMNParameterMapping>();
        }

        public string AssemblyQualifiedName { get; set; }
        /// <summary>
        /// Zero or more ParameterMapping objects. A ParameterMapping of a ProcessTask specifies how an input of the ProcessTask is mapped to an
        /// input of the called Process and how an output of the called Process is mapped to an output of the ProcessTask
        /// </summary>
        public ICollection<CMMNParameterMapping> Mappings { get; set; }
        /// <summary>
        /// A reference to a Process. If ProcessRef is not specified then processRefExpression must be specified. [1..1]
        /// </summary>
        public string ProcessRef { get; set; }
        /// <summary>
        /// If processRefExpression is specified, it is assumed that the expression evaluates to a QName which is a valid QName of an existing Process. [0...1]
        /// </summary>
        public CMMNExpression ProcessRefExpression { get; set; }

        public override object CloneTask()
        {
            return new CMMNProcessTask(Name)
            {
                IsBlocking = IsBlocking,
                State = State,
                AssemblyQualifiedName = AssemblyQualifiedName,
                ProcessRef = ProcessRef,
                // ProcessRef = ProcessRef == null ? null : (CMMNProcess)ProcessRef.Clone(),
                ProcessRefExpression = ProcessRefExpression == null ? null : (CMMNExpression)ProcessRefExpression.Clone(),
                Name = Name
            };
        }
    }
}
