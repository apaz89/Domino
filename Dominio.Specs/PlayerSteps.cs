using System;
using System.Collections.Generic;
using System.Linq;
using Domino.Logic;
using Domino.Logic.Implementations;
using Domino.Logic.Intefaces;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
    [Binding]
    public class PlayerSteps
    {
        private DominoGame _domino;
        private Stock _stock;
        private List<Tile> _stockTilesList;
        private List<IPlayer> _playersList;
        private int _amountOfStockTiles;
        private int _playerWithLessTilesLeft;
        private int _numberOfTilesOnBoard = 0;
        private int _numberOfTilesInThePlayerGameTiles = 0;

        [Given(@"a Domino game")]
        public void GivenADominoGame()
        {
            _domino = new DominoGame();

            _domino.AddPlayer(new Player(1));
            _domino.AddPlayer(new Player(2));;

            _domino.GameBoard.AddTileToBoard(new Tile { Head = 6, Tail = 1 });
            _domino.GameBoard.AddTileToBoard(new Tile { Head = 1, Tail = 3 });
        }

        [Given(@"a stock")]
        public void GivenAStock(Table table)
        {
            _domino.Stock.Tiles = table.CreateSet<Tile>().ToList();
            //_stockTilesList = _domino.GameBoard.BoardTiles.ToList();
        }

        [Given(@"Player (.*) doesn't have a matching piece")]
        public void GivenPlayerDoesnTHaveAMatchingPiece(int p0)
        {
            var playerHaveMatchingPiece = _domino.PlayerHasMatchingPiece(p0 - 1);
            //Assert.AreEqual(false, playerHaveMatchingPiece);
        }

        [Given(@"a Domino StartBord")]
        public void GivenADominoStartBoard()
        {
            _domino.GameBoard.AddTileToBoard(new Tile { Head = 2, Tail = 2 });
        }

        [Given(@"is the turn of player one")]
        public void GivenIsTheTurnOfPlayerOne()
        {
            _domino = new DominoGame();
            _domino.AddPlayer(new Player(1));
            _domino.AddPlayer(new Player(2));
            _domino.InitializePlayersHand(7);

        }

        [Then(@"add (.*) tile to Player (.*) list of tiles")]
        public void ThenAddTileToPlayerListOfTiles(int p0, int p1)
        {

            var selectedPlayer = _domino.GetPlayer(p1);
            var actualAmountOfTiles = selectedPlayer.Hand.Count;

            _domino.GetPlayer(p1).Hand.Add(_domino.Stock.Tiles.First());
           
            var newAmountOfTiles = selectedPlayer.Hand.Count;

            Assert.Greater(newAmountOfTiles, actualAmountOfTiles);

        }

        [Then(@"remove (.*) tile from stock")]
        public void ThenRemoveTileFromStock(int p0)
        {
            _stockTilesList = _domino.Stock.Tiles;
            _amountOfStockTiles = _stockTilesList.Count;
            _domino.Stock.Tiles.RemoveAt(0);
            //var newAmountOfStockTiles = _stockTilesList.Count;

            Assert.Less(p0, _amountOfStockTiles);
        }

        [Given(@"an empty stock")]
        public void GivenAnEmptyStock()
        {
            _stockTilesList = _domino.GameBoard.BoardTiles;
            _stockTilesList.Clear();
            var stockTilesAmount = _stockTilesList.Count;
            Assert.AreEqual(0, stockTilesAmount);
        }

        [Then(@"validate the players pieces amount")]
        public void ThenValidateThePlayersPiecesAmount()
        {
            _playerWithLessTilesLeft = _domino.GetPlayerWithLessTilesLeft();
        }

        [Then(@"return player number with less pieces left")]
        public void ThenReturnPlayerNumberWithLessPiecesLeft()
        {
            try
            {
                Assert.AreEqual(1, _playerWithLessTilesLeft, "Player 1 is the winner");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(-1, _playerWithLessTilesLeft, "There was a tie");
            }

        }
        //////////////
        /// //////////
        /// //////////
        [When(@"the player one has the following sets of tiles")]
        public void WhenThePlayerOneHasTheFollowingSetsOfTiles(Table table)
        {
            _domino.GetPlayerAtTurn(0).Hand = table.CreateSet<Tile>().ToList();
            _domino.AssignHandWinner();
        }

        [When(@"the player two has the following set of tiles")]
        public void WhenPlayerTwoHasTheFollowingSetOfTiles(Table table)
        {
            _domino.GetPlayerAtTurn(1).Hand = table.CreateSet<Tile>().ToList();
        }

        [When(@"Player one puts his piece on the board")]
        public void WhenPlayerOnePutsHisPieceOnTheBoard()
        {
            _domino.Move(5, _domino.GameBoard.BoardTiles.Count-1);
        }

        [Then(@"is the turn of the player (.*)")]
        public void ThenIsTheTurnOfThePlayer(int p0)
        {
            Assert.AreEqual(p0, _domino.PlayerTurn);
        }

        [When(@"the board has the next set of tiles")]
        public void WhenTheBoardHasTheNextSetOfTiles(Table table)
        {
            var taTiles = table.CreateSet<Tile>().ToList();
            _domino.GameBoard.BoardTiles = taTiles;
            _numberOfTilesOnBoard = _domino.GameBoard.BoardTiles.Count;
            _numberOfTilesInThePlayerGameTiles = _domino.GetPlayerAtTurn(0).Hand.Count;
        }

        [When(@"the player place a tile on the board")]
        public void WhenThePlayerPlaceATileOnTheBoard()
        {
            var tile = _domino.GetPlayerAtTurn(0).PopTileAtIndex(1);
            _domino.GameBoard.AddTileToBoard(tile);
        }

        [Then(@"the tiles on board must increase by (.*)")]
        public void ThenTheTilesOnBoardMustIncreaseBy(int p0)
        {
            Assert.AreEqual(_numberOfTilesOnBoard + p0, _domino.GameBoard.BoardTiles.Count);
        }

        [Then(@"the tiles on the hand of the player must decrease by (.*)")]
        public void ThenTheTilesOnTheHandOfThePlayerMustDecreaseBy(int p0)
        {
            Assert.AreEqual(_domino.GetPlayerAtTurn(0).Hand.Count, _numberOfTilesInThePlayerGameTiles - p0);
        }
    }
}
