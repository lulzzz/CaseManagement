// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CaseManagement.HumanTasks.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class HumanTaskInstancesFeature : Xunit.IClassFixture<HumanTaskInstancesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "HumanTaskInstances.feature"
#line hidden
        
        public HumanTaskInstancesFeature(HumanTaskInstancesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "HumanTaskInstances", "\tCheck /humantaskinstances", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Create human task instance")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Create human task instance")]
        public virtual void CreateHumanTaskInstance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create human task instance", null, ((string[])(null)));
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table24.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 5
 testRunner.When("authenticate", ((string)(null)), table24, "When ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table25.AddRow(new string[] {
                        "humanTaskName",
                        "addClient"});
            table25.AddRow(new string[] {
                        "operationParameters",
                        "{ \"isGoldenClient\": \"true\", \"firstName\": \"FirstName\" }"});
#line 8
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table25, "And ");
#line 12
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/details\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("extract JSON from body into \'detailsHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 16
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/history\'", ((string)(null)), table26, "And ");
#line 18
 testRunner.And("extract JSON from body into \'historyHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON exists \'id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'name\'=\'addClient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'status\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].userPrincipal\'=\'taskIni" +
                    "tiator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].eventType\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].endOwner\'=\'administrato" +
                    "r\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].taskStatus\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Create deferred human task instance (activated after 5 seconds)")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Create deferred human task instance (activated after 5 seconds)")]
        public virtual void CreateDeferredHumanTaskInstanceActivatedAfter5Seconds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create deferred human task instance (activated after 5 seconds)", null, ((string[])(null)));
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table27.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 30
 testRunner.When("authenticate", ((string)(null)), table27, "When ");
#line 33
 testRunner.And("add \'5\' seconds into \'activationDeferralTime\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table28.AddRow(new string[] {
                        "humanTaskName",
                        "addClient"});
            table28.AddRow(new string[] {
                        "operationParameters",
                        "{ \"isGoldenClient\": \"true\", \"firstName\": \"FirstName\" }"});
            table28.AddRow(new string[] {
                        "activationDeferralTime",
                        "$activationDeferralTime$"});
#line 34
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table28, "And ");
#line 39
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("poll \'http://localhost/humantaskinstances/$humanTaskInstanceId$/details\', until \'" +
                    "status\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("extract JSON from body into \'detailsHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 43
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/history\'", ((string)(null)), table29, "And ");
#line 45
 testRunner.And("extract JSON from body into \'historyHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON exists \'id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'name\'=\'addClient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'status\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].userPrincipal\'=\'taskIni" +
                    "tiator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].eventType\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].taskStatus\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].userPrincipal\'=\'Process" +
                    "ActivationTimer\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].eventType\'=\'ACTIVATE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].endOwner\'=\'administrato" +
                    "r\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].taskStatus\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Nominate a human task")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Nominate a human task")]
        public virtual void NominateAHumanTask()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Nominate a human task", null, ((string[])(null)));
#line 59
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table30.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 60
 testRunner.When("authenticate", ((string)(null)), table30, "When ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table31.AddRow(new string[] {
                        "humanTaskName",
                        "noPotentialOwner"});
#line 63
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table31, "And ");
#line 66
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table32.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "businessAdmin"});
#line 68
 testRunner.And("authenticate", ((string)(null)), table32, "And ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table33.AddRow(new string[] {
                        "userIdentifiers",
                        "[\"potentialOwner\"]"});
#line 71
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/nominate\'", ((string)(null)), table33, "And ");
#line 74
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/details\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("extract JSON from body into \'detailsHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 76
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/history\'", ((string)(null)), table34, "And ");
#line 78
 testRunner.And("extract JSON from body into \'historyHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON exists \'id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'name\'=\'noPotentialOwner\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'status\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].userPrincipal\'=\'taskIni" +
                    "tiator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].eventType\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].taskStatus\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].userPrincipal\'=\'busines" +
                    "sAdmin\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].eventType\'=\'ACTIVATE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].endOwner\'=\'potentialOwn" +
                    "er\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].taskStatus\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get humantask instance description")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Get humantask instance description")]
        public virtual void GetHumantaskInstanceDescription()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get humantask instance description", null, ((string[])(null)));
#line 92
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table35.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 93
 testRunner.When("authenticate", ((string)(null)), table35, "When ");
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table36.AddRow(new string[] {
                        "humanTaskName",
                        "addClient"});
            table36.AddRow(new string[] {
                        "operationParameters",
                        "{ \"isGoldenClient\": \"true\", \"firstName\": \"FirstName\" }"});
#line 96
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table36, "And ");
#line 100
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table37.AddRow(new string[] {
                        "Accept-Language",
                        "en-US"});
#line 102
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/description\'", ((string)(null)), table37, "And ");
#line 106
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.Then("html = \'<b>firstname is FirstName, isGoldenClient true</b>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Claim a human task instance")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Claim a human task instance")]
        public virtual void ClaimAHumanTaskInstance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Claim a human task instance", null, ((string[])(null)));
#line 109
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table38.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 110
 testRunner.When("authenticate", ((string)(null)), table38, "When ");
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table39.AddRow(new string[] {
                        "humanTaskName",
                        "multiplePotentialOwners"});
#line 113
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table39, "And ");
#line 116
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table40.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "administrator"});
#line 118
 testRunner.And("authenticate", ((string)(null)), table40, "And ");
#line 121
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/claim\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/details\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("extract JSON from body into \'detailsHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 124
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/history\'", ((string)(null)), table41, "And ");
#line 126
 testRunner.And("extract JSON from body into \'historyHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON exists \'id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'name\'=\'multiplePotentialOwners\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'status\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].userPrincipal\'=\'taskIni" +
                    "tiator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].eventType\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].taskStatus\'=\'READY\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].userPrincipal\'=\'adminis" +
                    "trator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].eventType\'=\'CLAIM\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].endOwner\'=\'administrato" +
                    "r\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].taskStatus\'=\'RESERVED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Start a human task instance")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskInstances")]
        [Xunit.TraitAttribute("Description", "Start a human task instance")]
        public virtual void StartAHumanTaskInstance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Start a human task instance", null, ((string[])(null)));
#line 140
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table42.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "taskInitiator"});
#line 141
 testRunner.When("authenticate", ((string)(null)), table42, "When ");
#line hidden
            TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table43.AddRow(new string[] {
                        "humanTaskName",
                        "multiplePotentialOwners"});
#line 144
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances\'", ((string)(null)), table43, "And ");
#line 147
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.And("extract \'id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table44.AddRow(new string[] {
                        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        "administrator"});
#line 149
 testRunner.And("authenticate", ((string)(null)), table44, "And ");
#line 152
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/start\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/details\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.And("extract JSON from body into \'detailsHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 155
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/history\'", ((string)(null)), table45, "And ");
#line 157
 testRunner.And("extract JSON from body into \'historyHumanTaskInstance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON exists \'id\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'name\'=\'multiplePotentialOwners\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
 testRunner.Then("extract JSON \'detailsHumanTaskInstance\', JSON \'status\'=\'INPROGRESS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].userPrincipal\'=\'taskIni" +
                    "tiator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].eventType\'=\'CREATED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[0].taskStatus\'=\'READY\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 166
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].userPrincipal\'=\'adminis" +
                    "trator\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].eventType\'=\'START\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].endOwner\'=\'administrato" +
                    "r\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.Then("extract JSON \'historyHumanTaskInstance\', JSON \'content[1].taskStatus\'=\'INPROGRESS" +
                    "\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HumanTaskInstancesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HumanTaskInstancesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
