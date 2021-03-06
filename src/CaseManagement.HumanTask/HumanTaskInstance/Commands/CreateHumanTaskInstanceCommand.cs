﻿using CaseManagement.HumanTask.Common;
using MediatR;
using System;
using System.Collections.Generic;

namespace CaseManagement.HumanTask.HumanTaskInstance.Commands
{
    public class CreateHumanTaskInstanceCommand : IRequest<string>
    {
        public CreateHumanTaskInstanceCommand()
        {
            OperationParameters = new Dictionary<string, string>();
            IgnorePermissions = false;
        }

        public string NameIdentifier { get; set; }
        public string HumanTaskName { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Claims { get; set; }
        public int? Priority { get; set; }
        public DateTime? ActivationDeferralTime { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public ICollection<AssignPeople> PeopleAssignments { get; set; }
        public ICollection<string> CallbackUrls { get; set; }
        public Dictionary<string, string> OperationParameters { get; set; }
        public bool IgnorePermissions { get; set; }
    }
}
