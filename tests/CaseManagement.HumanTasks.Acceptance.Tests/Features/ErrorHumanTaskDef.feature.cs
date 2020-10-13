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
    public partial class ErrorHumanTaskDefFeature : Xunit.IClassFixture<ErrorHumanTaskDefFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ErrorHumanTaskDef.feature"
#line hidden
        
        public ErrorHumanTaskDefFeature(ErrorHumanTaskDefFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ErrorHumanTaskDef", "\tCheck errors returned by /humantasksdefs", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(DisplayName="Check error is returned when trying to create task with missing name")]
        [Xunit.TraitAttribute("FeatureTitle", "ErrorHumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check error is returned when trying to create task with missing name")]
        public virtual void CheckErrorIsReturnedWhenTryingToCreateTaskWithMissingName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check error is returned when trying to create task with missing name", null, ((string[])(null)));
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
#line 5
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table1, "When ");
#line 7
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.Then("JSON \'status\'=\'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.Then("JSON \'errors.bad_request[0]\'=\'Parameter \'name\' is missing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check error is returned when trying to add humantaskdef with same name")]
        [Xunit.TraitAttribute("FeatureTitle", "ErrorHumanTaskDef")]
        [Xunit.TraitAttribute("Description", "Check error is returned when trying to add humantaskdef with same name")]
        public virtual void CheckErrorIsReturnedWhenTryingToAddHumantaskdefWithSameName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check error is returned when trying to add humantaskdef with same name", null, ((string[])(null)));
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table2.AddRow(new string[] {
                        "name",
                        "name"});
#line 14
 testRunner.When("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table3.AddRow(new string[] {
                        "name",
                        "name"});
#line 17
 testRunner.And("execute HTTP POST JSON request \'http://localhost/humantasksdefs\'", ((string)(null)), table3, "And ");
#line 20
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.Then("JSON \'status\'=\'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.Then("JSON \'errors.bad_request[0]\'=\'The human task def \'name\' already exists\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ErrorHumanTaskDefFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ErrorHumanTaskDefFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
