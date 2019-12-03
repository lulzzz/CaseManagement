﻿namespace CaseManagement.CMMN
{
    public static class CMMNConstants
    {
        public static class RouteNames
        {
            public const string CaseDefinitions = "case-definitions";
            public const string CaseInstances = "case-instances";
            public const string CaseProcesses = "case-processes";
        }

        public static class ProcessImplementationTypes
        {
            public const string BMNN20 = "http://www.omg.org/spec/CMMN/ProcessType/BPMN20";
            public const string XPDL2 = "http://www.omg.org/spec/CMMN/ProcessType/XPDL2";
            public const string WSBPEL20 = "http://www.omg.org/spec/CMMN/ProcessType/WSBPEL20";
            public const string WSBPEL1 = "http://www.omg.org/spec/CMMN/ProcessType/WSBPEL1";
            public const string CASEMANAGEMENTCALLBACK = "https://github.com/simpleidserver/CaseManagement/callback";
        }
    }
}