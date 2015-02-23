using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;
using TechTalk.SpecFlow;

namespace Domino.Logic.Implementation
{
    public class DominoGame
    {
        public DominoGame()
        {
            Board = new Board();
        }

        private static IRandom _iRandom;
        private Stock _stock = new Stock(_iRandom);
        private List<Player> _playersList = new List<Player>();
        private Board _board = new Board();

        public int PlayerTurn { get; set; }
        public Board Board { get; set; }

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

        private int GetNumberPlayers()
        {
            return _playersList.Count;
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
            _playersList.ElementAt(playerNumber - 1).AddTilesToTilesList(newTile);
        }

        public List<Tile> ConvertListTilesTotechTalk(Table techTalk)
        {
            return
                techTalk.Rows.Select(row => new Tile(Convert.ToInt32(row["Head"]), Convert.ToInt32(row["Tail"])))
                    .ToList();
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

            if (equals == 0)
                return playerNumber;

            return -1;

        }

        public Player GetPlayerAtTurn(int turno)
        {
            if (turno < GetNumberPlayers())
                return (Player) _playersList.ElementAt(turno);
            return null;
        }


        public void InitializeTurns()
        {
            PlayerTurn = GetPlayerStarted();
        }

        public int GetPlayerStarted()
        {
            int playerStartPosition = 0;
            var topTileScore = new Tile(-1, -1);
            bool isDoublePieces = false;

            for (int i = 0; i < _playersList.Count; i++)
            {
                Tile tile = _playersList.ElementAt(i).GetMoveValueTitle();
                if (tile.IsNumeric)
                {
                    if (tile.Head > topTileScore.Head && tile.Tail > topTileScore.Tail)
                    {
                        playerStartPosition = i;
                        topTileScore = tile;
                    }

                    isDoublePieces = true;
                }
                else
                {
                    if (!isDoublePieces)
                    {
                        int sumNomal = tile.Head + tile.Tail;
                        int sumTop = topTileScore.Head + topTileScore.Tail;

                        if (sumNomal > sumTop)
                        {
                            playerStartPosition = i;
                            topTileScore = tile;
                        }
                    }
                }
            }
            return playerStartPosition;
        }

        public void Move(int positionGameTiles, int positionBoard)
        {
            if (Ismove(positionGameTiles, positionBoard))
            {
                Board._boardTilesList[positionBoard] =
                    _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionGameTiles);
                _playersList.ElementAt(PlayerTurn).GameTiles.RemoveAt(positionGameTiles);
                NextPlayerTurn();
            }
        }

        public bool Ismove(int positionHand, int positionBoard)
        {
            bool move = true;
            if (Board._boardTilesList[positionBoard].Head == -1)
            {
                if (positionBoard == 27)
                {
                    if (Board._boardTilesList[positionBoard - 1].Head ==
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                        !Board._boardTilesList[positionBoard - 1].HeadTaked)
                    {
                        Board._boardTilesList[positionBoard - 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard - 1].Head ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                             !Board._boardTilesList[positionBoard - 1].HeadTaked)
                    {
                        Board._boardTilesList[positionBoard - 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard == 0)
                {
                    if (Board._boardTilesList[positionBoard + 1].Tail ==
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                        !Board._boardTilesList[positionBoard + 1].TailTaked)
                    {
                        Board._boardTilesList[positionBoard + 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard + 1].Tail ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                             !Board._boardTilesList[positionBoard + 1].TailTaked)
                    {
                        Board._boardTilesList[positionBoard + 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard > 0 && positionBoard < 27)
                {
                    if (Board._boardTilesList[positionBoard - 1].Head ==
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                        !Board._boardTilesList[positionBoard - 1].HeadTaked)
                    {
                        Board._boardTilesList[positionBoard - 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard - 1].Tail ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                             !Board._boardTilesList[positionBoard - 1].TailTaked)
                    {
                        Board._boardTilesList[positionBoard - 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard + 1].Tail ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                             !Board._boardTilesList[positionBoard + 1].TailTaked)
                    {
                        Board._boardTilesList[positionBoard + 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard + 1].Head ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                             !Board._boardTilesList[positionBoard + 1].HeadTaked)
                    {
                        Board._boardTilesList[positionBoard + 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard - 1].Head ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                             !Board._boardTilesList[positionBoard - 1].HeadTaked)
                    {
                        Board._boardTilesList[positionBoard - 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard + 1].Tail ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                             !Board._boardTilesList[positionBoard + 1].TailTaked)
                    {
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        Board._boardTilesList[positionBoard + 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard + 1].Head ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Head &&
                             !Board._boardTilesList[positionBoard + 1].HeadTaked)
                    {
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        Board._boardTilesList[positionBoard + 1].HeadTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (Board._boardTilesList[positionBoard - 1].Tail ==
                             _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Tail &&
                             !Board._boardTilesList[positionBoard - 1].TailTaked)
                    {
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).Swap();
                        Board._boardTilesList[positionBoard - 1].TailTaked = true;
                        _playersList.ElementAt(PlayerTurn).GameTiles.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
            }
            return move;
        }

        public void NextPlayerTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > _playersList.Count - 1)
                PlayerTurn = 0;
        }

        public void InitializePlayersHand(int amountOfTilesForEachPlayer)
        {
            foreach (IPlayer player in _playersList)
            {
                for (int i = 0; i < amountOfTilesForEachPlayer; i++)
                {
                    player.AddTileToGame(_stock.PopFromStock());
                }

            }
        }
    }
}
