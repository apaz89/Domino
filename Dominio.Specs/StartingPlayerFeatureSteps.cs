﻿using System.Linq;
using Domino.Logic;
using Domino.Logic.Implementations;
using Domino.Logic.Intefaces;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
   [Binding]
    public class StartingPlayerFeatureSteps
    {

        private DominoGame _game;

        private static int _playerCount = 1;
        readonly IPlayer _player1 = new Player(_playerCount++);
        readonly IPlayer _player2 = new Player(_playerCount++);

        [Given(@"A new game")]
        public void GivenANewGame()
        {
            _game = new DominoGame();
            _game.AddPlayer(_player1);
            _game.AddPlayer(_player2);
        }

        [When(@"Player one has seven tiles")]
        public void WhenPlayerOneHasTiles(Table table)
        {
            _game.GetPlayer(1).Hand = table.CreateSet<Tile>().ToList();
        }

        [When(@"Player two has seven tiles")]
        public void WhenPlayerTwoHasTiles(Table table)
        {
            _game.GetPlayer(2).Hand = table.CreateSet<Tile>().ToList();
            _game.AssignHandWinner();
        }
        
        [Then(@"Player (.*) should be the starting player")]
        public void ThenPlayerShouldBeTheStartingPlayer(int p0)
        {
            Assert.AreEqual(p0, _game.GetStartingPlayer());
        }
    }
}
