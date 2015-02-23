using System;
using System.Collections.Generic;
using System.Linq;
using Domino.Logic;
using Domino.Logic.Implementation;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace Dominio.Specs
    {
        [Binding]
        public class PlayerSteps
            {
                private DominoGame _domino = new DominoGame();
                private List<Tile> _stockTilesList;
                private List<Player> _playersList;
                private int _amountOfStockTiles;
                private int _playerWithLessTilesLeft;
                private int _numberOfTilesOnBoard = 0;
                private int _numberOfTilesInThePlayerGameTiles = 0;

                [Given(@"a Domino game")]
                public void GivenADominoGame()
                {
                    _domino.AddNewPlayer();
                    _domino.AddNewPlayer();
                    
                    _domino.GetBoard().AddTileToBoard(new Tile{Head = 6,Tail = 1});
                    _domino.GetBoard().AddTileToBoard(new Tile { Head = 1, Tail = 3 });
                }

                [Given(@"a stock")]
                public void GivenAStock()
                {
                    _stockTilesList = _domino.GetGameStock().Tiles;
                }

                [Given(@"Player (.*) doesn't have a matching piece")]
                public void GivenPlayerDoesnTHaveAMatchingPiece(int p0)
                {
                    var playerHaveMatchingPiece = _domino.PlayerHasMatchingPiece(p0 - 1);
                    Assert.AreEqual(false, playerHaveMatchingPiece);
                }

                [Given(@"a Domino StartBord")]
                public void GivenADominoStartBoard()
                {
                    _domino.Board._boardTilesList.ElementAt(10).Head = 2;
                    _domino.Board._boardTilesList.ElementAt(10).Tail = 2;
                }

                [Given(@"is the turn of player one")]
                public void GivenIsTheTurnOfPlayerOne()
                {
                    _domino = new DominoGame();
                    _domino.AddNewPlayer();
                    _domino.AddNewPlayer();
                    _domino.InitializePlayersHand(7);

                }

                [Then(@"add (.*) tile to Player (.*) list of tiles")]
                public void ThenAddTileToPlayerListOfTiles(int p0, int p1)
                {
                    _playersList = _domino.GetPlayersList();
                    var selectedPlayer = _playersList.ElementAt(p1 - 1);
                    var actualAmountOfTiles = selectedPlayer.GetPlayersTileList().Count;
                    _amountOfStockTiles = _stockTilesList.Count;

                    selectedPlayer.AddTilesToTilesList(_domino.GetGameStock().PopTileFromStock());

                    var newAmountOfTiles = selectedPlayer.GetPlayersTileList().Count;

                    Assert.Greater(newAmountOfTiles, actualAmountOfTiles);

                }

                [Then(@"remove (.*) tile from stock")]
                public void ThenRemoveTileFromStock(int p0)
                {
                    var newAmountOfStockTiles = _stockTilesList.Count;

                    Assert.Less(newAmountOfStockTiles, _amountOfStockTiles);
                }

                [Given(@"an empty stock")]
                public void GivenAnEmptyStock()
                {
                    _stockTilesList = _domino.GetGameStock().Tiles;
                    _stockTilesList.Clear();
                    var stockTilesAmount = _stockTilesList.Count;
                    Assert.AreEqual(0,stockTilesAmount);
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
                        Assert.AreEqual(1, _playerWithLessTilesLeft,"Player 1 is the winner");
                    }
                    catch (Exception ex)
                    {
                        Assert.AreEqual(-1, _playerWithLessTilesLeft,"There was a tie");
                    }
                    
                }
                //////////////
                /// //////////
                /// //////////
                [When(@"the player one has the following sets of tiles")]
                public void WhenThePlayerOneHasTheFollowingSetsOfTiles(Table table)
                {
                    _domino.GetPlayerAtTurn(0).GameTiles = _domino.ConvertListTilesTotechTalk(table);
                    _domino.InitializeTurns();
                }

                [When(@"the player two has the following set of tiles")]
                public void WhenPlayerTwoHasTheFollowingSetOfTiles(Table table)
                {
                    _domino.GetPlayerAtTurn(1).GameTiles = _domino.ConvertListTilesTotechTalk(table);
                }

                [When(@"Player one puts his piece on the board")]
                public void WhenPlayerOnePutsHisPieceOnTheBoard()
                {
                    _domino.Move(5, 9);
                }

                [Then(@"is the turn of the player (.*)")]
                public void ThenIsTheTurnOfThePlayer(int p0)
                {
                    Assert.AreEqual(p0, _domino.GetPlayerStarted() + 1);
                }

                [When(@"the board has the next set of tiles")]
                public void WhenTheBoardHasTheNextSetOfTiles(Table table)
                {
                    var taTiles = _domino.ConvertListTilesTotechTalk(table).ToArray();
                    _domino.Board._boardTilesList = new List<Tile>(taTiles);
                    _numberOfTilesOnBoard = _domino.Board.TilesAmount;
                    _numberOfTilesInThePlayerGameTiles = _domino.GetPlayerAtTurn(0).GameTiles.Count;
                }

                [When(@"the player place a tile on the board")]
                public void WhenThePlayerPlaceATileOnTheBoard()
                {
                    var tile = _domino.GetPlayerAtTurn(0).PopTileAtIndex(1);
                    _domino.Board._boardTilesList[_domino.Board._boardTilesList.Count - 1] = tile;
                }

                [Then(@"the tiles on board must increase by (.*)")]
                public void ThenTheTilesOnBoardMustIncreaseBy(int p0)
                {
                    Assert.AreEqual(_numberOfTilesOnBoard + p0, _domino.Board.TilesAmount);
                }

                [Then(@"the tiles on the hand of the player must decrease by (.*)")]
                public void ThenTheTilesOnTheHandOfThePlayerMustDecreaseBy(int p0)
                {
                    Assert.AreEqual(_domino.GetPlayerAtTurn(0).GameTiles.Count, _numberOfTilesInThePlayerGameTiles - p0);
                }
            }

    }
