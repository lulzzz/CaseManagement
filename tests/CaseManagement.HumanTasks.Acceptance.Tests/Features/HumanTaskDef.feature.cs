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
    public partial class HumanTaskDefFeature : Xunit.IClassFixture<HumanTaskDefFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "HumanTaskDef.feature"
#line hidden
        
        public HumanTaskDefFeature(HumanTaskDefFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "HumanTaskDef", "\tCheck errors returned by /humantasksdefs", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(DisplayName="Check humantask can be created")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check humantask can be created")]
        public virtual void CheckHumantaskCanBeCreated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check humantask can be created", null, ((string[])(null)));
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table79 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table79.AddRow(new string[] {
                        "name",
                        "newName"});
#line 5
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table79, "When ");
#line 8
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("HTTP status code equals to \'201\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.Then("JSON \'name\'=\'newName\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check humantaskdef info can be updated")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check humantaskdef info can be updated")]
        public virtual void CheckHumantaskdefInfoCanBeUpdated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check humantaskdef info can be updated", null, ((string[])(null)));
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table80 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table80.AddRow(new string[] {
                        "name",
                        "oldName"});
#line 14
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table80, "When ");
#line 17
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table81 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table81.AddRow(new string[] {
                        "name",
                        "newName2"});
#line 19
 testRunner.And("execute HTTP PUT JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/i" +
                    "nfo\'", ((string)(null)), table81, "And ");
#line 22
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.Then("JSON \'name\'=\'newName2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check parameter can be added")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check parameter can be added")]
        public virtual void CheckParameterCanBeAdded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check parameter can be added", null, ((string[])(null)));
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table82 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table82.AddRow(new string[] {
                        "name",
                        "addInputParameter"});
#line 29
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table82, "When ");
#line 32
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table83 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table83.AddRow(new string[] {
                        "parameter",
                        "{ name: \'parameter\', type: \'STRING\', usage : \'INPUT\' }"});
#line 34
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "parameters\'", ((string)(null)), table83, "And ");
#line 37
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.Then("JSON \'name\'=\'addInputParameter\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.Then("JSON \'operationParameters[0].name\'=\'parameter\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.Then("JSON \'operationParameters[0].type\'=\'STRING\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.Then("JSON \'operationParameters[0].usage\'=\'INPUT\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check parameter can be removed")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check parameter can be removed")]
        public virtual void CheckParameterCanBeRemoved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check parameter can be removed", null, ((string[])(null)));
#line 46
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table84 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table84.AddRow(new string[] {
                        "name",
                        "removeOutputParameter"});
#line 47
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table84, "When ");
#line 50
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table85 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table85.AddRow(new string[] {
                        "parameter",
                        "{ name: \'parameter\', type: \'STRING\', usage: \'OUTPUT\' }"});
#line 52
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "parameters\'", ((string)(null)), table85, "And ");
#line 55
 testRunner.And("execute HTTP DELETE request \'http://localhost/humantasksdefs/$humanTaskDefId$/par" +
                    "ameters/parameter\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.Then("JSON \'name\'=\'removeOutputParameter\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.Then("JSON nb \'operation.outputParameters[*]\'=\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check add deadline")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check add deadline")]
        public virtual void CheckAddDeadline()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check add deadline", null, ((string[])(null)));
#line 63
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table86 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table86.AddRow(new string[] {
                        "name",
                        "addStartDeadline"});
#line 64
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table86, "When ");
#line 67
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table87 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table87.AddRow(new string[] {
                        "deadLine",
                        "{ name: \"name\", until: \"P0Y0M0DT0H0M2S\", \"usage\": \"START\" }"});
#line 69
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines\'", ((string)(null)), table87, "And ");
#line 72
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
 testRunner.Then("JSON \'name\'=\'addStartDeadline\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.Then("JSON \'deadLines[0].name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
 testRunner.Then("JSON \'deadLines[0].usage\'=\'START\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
 testRunner.Then("JSON \'deadLines[0].until\'=\'P0Y0M0DT0H0M2S\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check deadline can be removed")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check deadline can be removed")]
        public virtual void CheckDeadlineCanBeRemoved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check deadline can be removed", null, ((string[])(null)));
#line 81
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table88 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table88.AddRow(new string[] {
                        "name",
                        "removeCompletionDeadline"});
#line 82
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table88, "When ");
#line 85
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table89 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table89.AddRow(new string[] {
                        "deadLine",
                        "{ name: \"name\", until: \"P0Y0M0DT0H0M2S\", \"usage\": \"COMPLETION\" }"});
#line 87
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines\'", ((string)(null)), table89, "And ");
#line 90
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("extract \'id\' from JSON body into \'deadLineId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("execute HTTP DELETE request \'http://localhost/humantasksdefs/$humanTaskDefId$/dea" +
                    "dlines/$deadLineId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.Then("JSON \'name\'=\'removeCompletionDeadline\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.Then("JSON nb \'deadLines.completionDeadLines[*]\'=\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check deadline can be updated")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check deadline can be updated")]
        public virtual void CheckDeadlineCanBeUpdated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check deadline can be updated", null, ((string[])(null)));
#line 100
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table90 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table90.AddRow(new string[] {
                        "name",
                        "updateStartDeadline"});
#line 101
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table90, "When ");
#line 104
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table91 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table91.AddRow(new string[] {
                        "deadLine",
                        "{ name: \"name\", until: \"P0Y0M0DT0H0M2S\", \"usage\": \"START\" }"});
#line 106
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines\'", ((string)(null)), table91, "And ");
#line 109
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("extract \'id\' from JSON body into \'deadLineId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table92 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table92.AddRow(new string[] {
                        "deadLineInfo",
                        "{ name: \"name2\", \"usage\": \"START\" }"});
#line 111
 testRunner.And("execute HTTP PUT JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/d" +
                    "eadlines/$deadLineId$\'", ((string)(null)), table92, "And ");
#line 114
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
 testRunner.Then("JSON \'name\'=\'updateStartDeadline\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.Then("JSON \'deadLines[0].name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.Then("JSON \'deadLines[0].until\'=\'P0Y0M0DT0H0M2S\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check escalation deadline can be added")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check escalation deadline can be added")]
        public virtual void CheckEscalationDeadlineCanBeAdded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check escalation deadline can be added", null, ((string[])(null)));
#line 122
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table93 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table93.AddRow(new string[] {
                        "name",
                        "addEscalationCompletionDeadline"});
#line 123
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table93, "When ");
#line 126
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table94 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table94.AddRow(new string[] {
                        "deadLine",
                        "{ name: \"name\", until: \"P0Y0M0DT0H0M2S\", \"usage\": \"COMPLETION\" }"});
#line 128
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines\'", ((string)(null)), table94, "And ");
#line 131
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("extract \'id\' from JSON body into \'deadLineId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table95 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table95.AddRow(new string[] {
                        "condition",
                        "true"});
#line 133
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines/$deadLineId$/escalations\'", ((string)(null)), table95, "And ");
#line 136
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
 testRunner.Then("JSON \'name\'=\'addEscalationCompletionDeadline\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.Then("JSON \'deadLines[0].name\'=\'name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.Then("JSON \'deadLines[0].until\'=\'P0Y0M0DT0H0M2S\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
 testRunner.Then("JSON \'deadLines[0].escalations[0].condition\'=\'true\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
 testRunner.Then("JSON \'deadLines[0].usage\'=\'COMPLETION\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check escalation can be removed from deadline")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check escalation can be removed from deadline")]
        public virtual void CheckEscalationCanBeRemovedFromDeadline()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check escalation can be removed from deadline", null, ((string[])(null)));
#line 146
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table96 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table96.AddRow(new string[] {
                        "name",
                        "removeEscalationStartDeadline"});
#line 147
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table96, "When ");
#line 150
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table97 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table97.AddRow(new string[] {
                        "deadLine",
                        "{ name: \"name\", until: \"P0Y0M0DT0H0M2S\", \"usage\": \"START\" }"});
#line 152
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines\'", ((string)(null)), table97, "And ");
#line 155
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.And("extract \'id\' from JSON body into \'deadLineId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table98 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table98.AddRow(new string[] {
                        "condition",
                        "true"});
#line 157
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/" +
                    "deadlines/$deadLineId$/escalations\'", ((string)(null)), table98, "And ");
#line 160
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And("extract \'id\' from JSON body into \'escId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.And("execute HTTP DELETE request \'http://localhost/humantasksdefs/$humanTaskDefId$/dea" +
                    "dlines/$deadLineId$/escalations/$escId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
 testRunner.Then("JSON \'name\'=\'removeEscalationStartDeadline\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
 testRunner.Then("JSON nb \'deadLines.startDeadLines[0].escalations[*]\'=\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check rendering can be updated")]
        [Xunit.TraitAttribute("FeatureTitle", "HumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check rendering can be updated")]
        public virtual void CheckRenderingCanBeUpdated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check rendering can be updated", null, ((string[])(null)));
#line 170
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table99 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table99.AddRow(new string[] {
                        "name",
                        "updateRendering"});
#line 171
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table99, "When ");
#line 174
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("extract \'id\' from JSON body into \'humanTaskDefId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table100 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table100.AddRow(new string[] {
                        "renderingElements",
                        "[ { xPath: \'xpath\' }]"});
#line 176
 testRunner.And("execute HTTP PUT JSON request \'http://localhost/humantasksdefs/$humanTaskDefId$/r" +
                    "endering\'", ((string)(null)), table100, "And ");
#line 179
 testRunner.And("execute HTTP GET request \'http://localhost/humantasksdefs/$humanTaskDefId$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
 testRunner.Then("JSON \'name\'=\'updateRendering\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 184
 testRunner.Then("JSON \'renderingElements[0].xPath\'=\'xPath\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HumanTaskDefFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HumanTaskDefFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
