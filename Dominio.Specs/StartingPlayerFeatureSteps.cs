using System;
using Domino.Logic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Dominio.Specs
{
    [Binding]
    public class StartingPlayerFeatureSteps
    {

        private Game _game;

        private static int _playerCount = 1;
        readonly Player _player1 = new Player(_playerCount++);
        readonly Player _player2 = new Player(_playerCount++);

        [Given(@"A new game")]
        public void GivenANewGame()
        {
            _game = new Game();
            _game.AddPlayer(_player1);
            _game.AddPlayer(_player2);
        }

        [When(@"Player one has seven tiles")]
        public void WhenPlayerOneHasTiles(Table table)
        {
            _game.GetPlayer(1).Hand = TableConverter.TableToList(table);
        }

        [When(@"Player two has seven tiles")]
        public void WhenPlayerTwoHasTiles(Table table)
        {
            _game.GetPlayer(2).Hand = TableConverter.TableToList(table);
            _game.AssignHandWinner();
        }
        
        [Then(@"Player (.*) should be the starting player")]
        public void ThenPlayerShouldBeTheStartingPlayer(int p0)
        {
            Assert.AreEqual(p0, _game.GetStartingPlayer());
        }
    }
}
