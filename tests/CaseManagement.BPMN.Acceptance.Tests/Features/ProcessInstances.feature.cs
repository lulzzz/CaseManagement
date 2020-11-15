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
namespace CaseManagement.BPMN.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ProcessInstancesFeature : Xunit.IClassFixture<ProcessInstancesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ProcessInstances.feature"
#line hidden
        
        public ProcessInstancesFeature(ProcessInstancesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ProcessInstances", "\tCheck result returned by /processinstances", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(DisplayName="Start BPMN process and complete human task instance")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessInstances")]
        [Xunit.TraitAttribute("Description", "Start BPMN process and complete human task instance")]
        public virtual void StartBPMNProcessAndCompleteHumanTaskInstance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Start BPMN process and complete human task instance", null, ((string[])(null)));
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.When("execute HTTP GET request \'http://localhost/processinstances/d33dadd922651238f7c9e" +
                    "c864068ee1ea5a64fc4f233ff001977ebdd82c2af44/start\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 6
 testRunner.And("poll HTTP POST JSON request \'http://localhost/humantaskinstances/.search\', until " +
                    "\'totalLength\'=\'1\'", ((string)(null)), table1, "And ");
#line 8
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("extract \'content[0].id\' from JSON body into \'humanTaskInstanceId\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("execute HTTP GET request \'http://localhost/humantaskinstances/$humanTaskInstanceI" +
                    "d$/start\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table2.AddRow(new string[] {
                        "operationParameters",
                        "{}"});
#line 11
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantaskinstances/$humanTaskIns" +
                    "tanceId$/complete\'", ((string)(null)), table2, "And ");
#line 14
 testRunner.And("poll \'http://localhost/processinstances/d33dadd922651238f7c9ec864068ee1ea5a64fc4f" +
                    "233ff001977ebdd82c2af44\', until \'elementInstances[0].state\'=\'Complete\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("poll \'http://localhost/processinstances/d33dadd922651238f7c9ec864068ee1ea5a64fc4f" +
                    "233ff001977ebdd82c2af44\', until \'elementInstances[1].state\'=\'Complete\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ProcessInstancesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProcessInstancesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
