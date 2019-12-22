﻿using System.Collections.Generic;
using System.Linq;

namespace CaseManagement.CMMN.Domains
{
    public class CMMNWorkflowDefinition
    {
        public CMMNWorkflowDefinition(string id, string name, string description, ICollection<CMMNWorkflowElementDefinition> elements)
        {
            Id = id;
            Name = name;
            Description = description;
            Elements = elements;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CMMNWorkflowElementDefinition> Elements { get; set; }

        public CMMNWorkflowElementDefinition GetElement(string id)
        {
            return GetElement(Elements, id);
        }

        public static CMMNWorkflowDefinition New(string id, string name, string description, ICollection<CMMNWorkflowElementDefinition> elements)
        {
            return new CMMNWorkflowDefinition(id, name, description, elements);
        }

        private CMMNWorkflowElementDefinition GetElement(ICollection<CMMNWorkflowElementDefinition> elements, string id)
        {
            var result = elements.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                return result;
            }

            
            foreach(var stage in elements.Where(e => e is CMMNStageDefinition).Cast<CMMNStageDefinition>())
            {
                result = GetElement(stage.Elements, id);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
