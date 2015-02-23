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

            }

    }
