using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Implementation
    {
        public class DominoGame
            {
                private static IRandom _iRandom;
                private Stock _stock = new Stock(_iRandom);
                private List<Player> _playersList = new List<Player>();
                private Board _board=new Board();

                public Stock GetGameStock()
                {
                    return _stock;
                }

                public Board GetBoard()
                {
                    return _board;
                }

                public List<Player> GetPlayersList()
                {
                    return _playersList;
                }

                public void AddNewPlayer()
                {
                    _playersList.Add(new Player());
                }

                public bool PlayerHasMatchingPiece(int playerNumber)
                {
                    var boardTilesList = _board.GetBoardTiles();

                    if (boardTilesList.Count == 0)
                        return true;

                    var firstTile = boardTilesList.ElementAt(0);
                    var lastTileIndex = boardTilesList.Count - 1;
                    var lastTile = boardTilesList.ElementAt(lastTileIndex);

                    var matchHeadValue = 0;
                    var matchTailValue = 0;

                    if (lastTileIndex > 1)
                    {
                        var nextTile = boardTilesList.ElementAt(1);
                        if (firstTile.Head != nextTile.Head && firstTile.Head != nextTile.Tail)
                        {
                            matchHeadValue = firstTile.Head;
                        }
                        else
                        {
                            matchHeadValue = firstTile.Tail;
                        }

                        var previousTile = boardTilesList.ElementAt(lastTileIndex - 1);
                        if (lastTile.Head != previousTile.Head && lastTile.Head != previousTile.Tail)
                        {
                            matchTailValue = lastTile.Head;
                        }
                        else
                        {
                            matchTailValue = lastTile.Tail;
                        }
                    }

                    foreach (var tile in _playersList.ElementAt(playerNumber).GetPlayersTileList())
                    {
                        if (tile.Head == matchHeadValue || tile.Tail == matchHeadValue)
                        {
                            return true;
                        }

                        if (tile.Head == matchTailValue || tile.Tail == matchTailValue)
                        {
                            return true;
                        }

                    }


                    return false;
                }

                public void AddTileToPlayerTilesList(int playerNumber)
                {
                    var newTile = _stock.PopTileFromStock();
                    _playersList.ElementAt(playerNumber-1).AddTilesToTilesList(newTile);
                }

                public int GetPlayerWithLessTilesLeft()
                {
                    const int minAmount = 28;
                    var playerNumber = -1;
                    var equals = 0;

                    foreach (var player in _playersList)
                    {
                        var tilesAmount = player.GetPlayersTileList().Count;

                        if (tilesAmount <= minAmount)
                        {
                            if (tilesAmount == minAmount)
                            {
                                equals++;
                            }
                            playerNumber++;
                        }
                    }

                    if(equals==0)
                        return playerNumber;
                    
                    return -1;
                    
                }

            }
    }
