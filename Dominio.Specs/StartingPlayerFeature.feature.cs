﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dominio.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("StartingPlayerFeature")]
    public partial class StartingPlayerFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StartingPlayerFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StartingPlayerFeature", "In order to determine the starting player\r\nAs a domino player\r\nI want to decide w" +
                    "ho meets the conditions", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Player one has the highest sum of a tile and neither have double tiles")]
        public virtual void PlayerOneHasTheHighestSumOfATileAndNeitherHaveDoubleTiles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Player one has the highest sum of a tile and neither have double tiles", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("A new game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Head",
                        "Tail"});
            table1.AddRow(new string[] {
                        "0",
                        "3"});
            table1.AddRow(new string[] {
                        "0",
                        "5"});
            table1.AddRow(new string[] {
                        "5",
                        "6"});
            table1.AddRow(new string[] {
                        "0",
                        "1"});
            table1.AddRow(new string[] {
                        "4",
                        "5"});
            table1.AddRow(new string[] {
                        "4",
                        "6"});
            table1.AddRow(new string[] {
                        "2",
                        "3"});
#line 9
 testRunner.When("Player one has seven tiles", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Head",
                        "Tail"});
            table2.AddRow(new string[] {
                        "3",
                        "4"});
            table2.AddRow(new string[] {
                        "2",
                        "4"});
            table2.AddRow(new string[] {
                        "2",
                        "5"});
            table2.AddRow(new string[] {
                        "0",
                        "2"});
            table2.AddRow(new string[] {
                        "2",
                        "6"});
            table2.AddRow(new string[] {
                        "1",
                        "5"});
            table2.AddRow(new string[] {
                        "1",
                        "4"});
#line 19
 testRunner.When("Player two has seven tiles", ((string)(null)), table2, "When ");
#line 45
 testRunner.Then("Player 1 should be the starting player", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
