﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
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
    [NUnit.Framework.DescriptionAttribute("Player")]
    public partial class PlayerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Player.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Player", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Player one gets a tile from stock")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void PlayerOneGetsATileFromStock()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Player one gets a tile from stock", new string[] {
                        "mytag"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("a Domino game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("a stock", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("Player 1 doesn\'t have a matching piece", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.Then("add 1 tile to Player 1 list of tiles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("remove 1 tile from stock", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The winner is the player with less quantity of pieces left")]
        public virtual void TheWinnerIsThePlayerWithLessQuantityOfPiecesLeft()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The winner is the player with less quantity of pieces left", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("a Domino game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("an empty stock", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Player 1 doesn\'t have a matching piece", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("validate the players pieces amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.And("return player number with less pieces left", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When player 1 puts a piece on the board is the player\'s turn 2, where is the 2 is" +
            " the turn of one.")]
        public virtual void WhenPlayer1PutsAPieceOnTheBoardIsThePlayerSTurn2WhereIsThe2IsTheTurnOfOne_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When player 1 puts a piece on the board is the player\'s turn 2, where is the 2 is" +
                    " the turn of one.", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("a Domino game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("a Domino StartBord", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table1.AddRow(new string[] {
                        "0",
                        "6"});
            table1.AddRow(new string[] {
                        "0",
                        "5"});
            table1.AddRow(new string[] {
                        "0",
                        "2"});
            table1.AddRow(new string[] {
                        "1",
                        "2"});
            table1.AddRow(new string[] {
                        "5",
                        "2"});
            table1.AddRow(new string[] {
                        "0",
                        "6"});
            table1.AddRow(new string[] {
                        "1",
                        "3"});
#line 24
 testRunner.When("the player one has the following sets of tiles", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table2.AddRow(new string[] {
                        "0",
                        "2"});
            table2.AddRow(new string[] {
                        "1",
                        "3"});
            table2.AddRow(new string[] {
                        "1",
                        "2"});
            table2.AddRow(new string[] {
                        "1",
                        "5"});
            table2.AddRow(new string[] {
                        "2",
                        "6"});
            table2.AddRow(new string[] {
                        "2",
                        "2"});
            table2.AddRow(new string[] {
                        "2",
                        "3"});
#line 33
 testRunner.And("the player two has the following set of tiles", ((string)(null)), table2, "And ");
#line 42
 testRunner.And("Player one puts his piece on the board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("is the turn of the player 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When The player puts a Tile on the Board")]
        public virtual void WhenThePlayerPutsATileOnTheBoard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When The player puts a Tile on the Board", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("is the turn of player one", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table3.AddRow(new string[] {
                        "0",
                        "1"});
            table3.AddRow(new string[] {
                        "0",
                        "6"});
            table3.AddRow(new string[] {
                        "0",
                        "5"});
            table3.AddRow(new string[] {
                        "1",
                        "3"});
            table3.AddRow(new string[] {
                        "5",
                        "6"});
            table3.AddRow(new string[] {
                        "0",
                        "2"});
            table3.AddRow(new string[] {
                        "1",
                        "2"});
#line 50
 testRunner.When("the board has the next set of tiles", ((string)(null)), table3, "When ");
#line 59
 testRunner.And("the player place a tile on the board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("the tiles on board must increase by 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("the tiles on the hand of the player must decrease by 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
