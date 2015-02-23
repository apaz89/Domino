using System;
using System.Linq;
using Domino.Logic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Dominio.Specs
{
    [Binding]
    public class UsingATileFeatureSteps
    {
        private Game _game;
        private Board _board;

        private static int _playerCount = 1;
        readonly Player _player1 = new Player(_playerCount++);
        readonly Player _player2 = new Player(_playerCount++);

        [Given(@"A new game with a clean board")]
        public void GivenANewGameWithACleanBoard()
        {
            _board = new Board();

            _game = new Game(_board);
            _game.AddPlayer(_player1);
            _game.AddPlayer(_player2);

        }

        [Given(@"Player one has seven tiles in the hand")]
        public void GivenPlayerOneHasSevenTilesInTheHand(Table table)
        {
            _game.GetPlayer(1).Hand = TableConverter.TableToList(table);
        }

        [Given(@"Player two has seven tiles in the hand")]
        public void GivenPlayerTwoHasSevenTilesInTheHand(Table table)
        {
            _game.GetPlayer(2).Hand = TableConverter.TableToList(table);
        }
        
        [Given(@"Player one starts playing")]
        public void GivenPlayerOneStartsPlaying()
        {
            _game.AssignHandWinner();
        }
        
        [When(@"The board has tiles placed")]
        public void WhenTheBoardHasTilesPlaced(Table table)
        {
            _game.GameBoard.BoardTiles = TableConverter.TableToList(table);
        }
        
        [When(@"Player one places one of his tiles on the board")]
        public void WhenPlayerOnePlacesOneOfHisTilesOnTheBoard()
        {
            int numberOfTilesOnBoard = _game.GameBoard.BoardTiles.Count;
            const int playerNumber = 1;
            _game.PlaceTileOnBoard(playerNumber,numberOfTilesOnBoard,0);
        }
        
        [Then(@"the tile must be removed from his hand")]
        public void ThenTheTileMustBeRemovedFromHisHand()
        {
            int numberOfPlayerTiles = _game.Players.ElementAt(0).Hand.Count;
            Assert.AreEqual(6, numberOfPlayerTiles);
        }
        
        [Then(@"the tile must be added to the board")]
        public void ThenTheTileMustBeAddedToTheBoard()
        {
            int numberOfTilesOnBoard = _game.GameBoard.BoardTiles.Count;
            Assert.AreEqual(6, numberOfTilesOnBoard);
        }
    }
}
