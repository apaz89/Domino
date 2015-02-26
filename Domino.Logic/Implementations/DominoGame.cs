using System.Collections.Generic;
using System.Linq;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class DominoGame:IDominoGame
    {
        #region Public Properties

        public List<IPlayer> Players { get; set; }
        public IBoard GameBoard { get; set; }
        public IStock Stock { get; set; }
        public int PlayerTurn { get; set; }

        #endregion

        #region Private Properties

        private readonly IPlayer _player;

        #endregion

        #region Constructors
        /// <summary>
        /// bueno para produccion
        /// </summary>
        /// <param name="board"></param>
        public DominoGame(IBoard board) 
        {
            Players = new List<IPlayer>();
            GameBoard = board;
            Stock = new Stock();
            PlayerTurn = 0;
        }

        public DominoGame()
        {
            Players = new List<IPlayer>();
            GameBoard = new Board();
            Stock=new Stock();
            PlayerTurn = 0;
        }
        #endregion

        #region Public Methods

        public void InitializePlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player(i);
                AddPlayer(player);
                InitializePlayersHand(7);
            }
        }

        public void Move(int positionGameTiles, int positionBoard)
        {
            if (Ismove(positionGameTiles, positionBoard))
            {
                GameBoard.BoardTiles[positionBoard] =
                    Players.ElementAt(PlayerTurn).Hand.ElementAt(positionGameTiles);
                Players.ElementAt(PlayerTurn).Hand.RemoveAt(positionGameTiles);
                NextPlayerTurn();
            }
        }

        public bool Ismove(int positionHand, int positionBoard)
        {
            var move = true;
            if (GameBoard.BoardTiles[positionBoard].Head == -1)
            {
                if (positionBoard == 27)
                {
                    if (GameBoard.BoardTiles[positionBoard - 1].Head ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                        !GameBoard.BoardTiles[positionBoard - 1].HeadTaked)
                    {
                        GameBoard.BoardTiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard - 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !GameBoard.BoardTiles[positionBoard - 1].HeadTaked)
                    {
                        GameBoard.BoardTiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard == 0)
                {
                    if (GameBoard.BoardTiles[positionBoard + 1].Tail ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                        !GameBoard.BoardTiles[positionBoard + 1].TailTaked)
                    {
                        GameBoard.BoardTiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !GameBoard.BoardTiles[positionBoard + 1].TailTaked)
                    {
                        GameBoard.BoardTiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
                else if (positionBoard > 0 && positionBoard < 27)
                {
                    if (GameBoard.BoardTiles[positionBoard - 1].Head ==
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                        !GameBoard.BoardTiles[positionBoard - 1].HeadTaked)
                    {
                        GameBoard.BoardTiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard - 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !GameBoard.BoardTiles[positionBoard - 1].TailTaked)
                    {
                        GameBoard.BoardTiles[positionBoard - 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !GameBoard.BoardTiles[positionBoard + 1].TailTaked)
                    {
                        GameBoard.BoardTiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard + 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !GameBoard.BoardTiles[positionBoard + 1].HeadTaked)
                    {
                        GameBoard.BoardTiles[positionBoard + 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard - 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !GameBoard.BoardTiles[positionBoard - 1].HeadTaked)
                    {
                        GameBoard.BoardTiles[positionBoard - 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard + 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !GameBoard.BoardTiles[positionBoard + 1].TailTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        GameBoard.BoardTiles[positionBoard + 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard + 1].Head ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Head &&
                             !GameBoard.BoardTiles[positionBoard + 1].HeadTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        GameBoard.BoardTiles[positionBoard + 1].HeadTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).TailTaked = true;
                    }
                    else if (GameBoard.BoardTiles[positionBoard - 1].Tail ==
                             Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Tail &&
                             !GameBoard.BoardTiles[positionBoard - 1].TailTaked)
                    {
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).Swap();
                        GameBoard.BoardTiles[positionBoard - 1].TailTaked = true;
                        Players.ElementAt(PlayerTurn).Hand.ElementAt(positionHand).HeadTaked = true;
                    }
                    else
                        move = false;
                }
            }
            return move;
        }

        

        public void InitializePlayersHand(int amountOfTilesForEachPlayer)
        {
            foreach (var player in Players)
            {
                for (var i = 0; i < amountOfTilesForEachPlayer; i++)
                {
                    player.Hand.Add(Stock.PopFromStock());
                }

            }
        }


        public int GetMaxDoublePiecePlayer()
        {
            var playerWithMaxDoublePiecePlayer = -1;
            var currentMaxDoubleTile = new Tile();
            foreach (var player in Players)
            {
                foreach (var tile in player.Hand)
                {
                    if (tile.Head != tile.Tail) continue;
                    if (currentMaxDoubleTile.Head < tile.Head && currentMaxDoubleTile.Tail < tile.Tail)
                    {
                        currentMaxDoubleTile = tile;
                        playerWithMaxDoublePiecePlayer = player.PlayerNumber;
                    }
                }
            }
            return playerWithMaxDoublePiecePlayer;
        }

        
        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
        }

        public int CalculateStartingPlayer()
        {
            var maxTileInPlayersHand = GetMaxDoublePiecePlayer();

            if (maxTileInPlayersHand != -1)
                return maxTileInPlayersHand;
            
            var maxSumTileOfPlayer= 0;
            foreach (var player in Players)
            {
                var tile = player.GetMostValuableSumTileInHand();
                var sumTiles = tile.Head + tile.Tail;

                if (sumTiles > maxSumTileOfPlayer)
                {
                    maxSumTileOfPlayer = sumTiles;
                    maxTileInPlayersHand = player.PlayerNumber;
                }
            }
            return maxTileInPlayersHand;
        }

        public int GetStartingPlayer()
        {
            return PlayerTurn;
        }

        public void AssignHandWinner()
        {
            PlayerTurn = CalculateStartingPlayer();
        }

        //public void AssignHandWinner(int predeterminedStarter)
        //{
        //    throw new NotImplementedException();
        //}

        public void PlaceTileOnBoard(int playerNumber, int numberOfTilesOnBoard, int tileToPlace)
        {
            var playerTile = Players.ElementAt(playerNumber - 1).Hand.ElementAt(tileToPlace);

            if (ValidateMovement(playerNumber, numberOfTilesOnBoard, tileToPlace))
            {
                Players.ElementAt(playerNumber - 1).Hand.Remove(playerTile);
                GameBoard.BoardTiles.Add(playerTile);
            }
        }

        public bool ValidateMovement(int playerNumber, int numberOfTilesOnBoard, int tileToPlace)
        {
            var lastPiece = GameBoard.BoardTiles.ElementAt(numberOfTilesOnBoard - 1);
            var playerTile = Players.ElementAt(playerNumber - 1).Hand.ElementAt(tileToPlace);

            if (playerTile.Head == lastPiece.Tail || playerTile.Tail == lastPiece.Tail)
            {
                return true;
            }
            return false;
        }

        public Player GetPlayer(int playerNumber)
        {
            return (Player)Players.ElementAt(playerNumber - 1);

        }


        public bool PlayerHasMatchingPiece(int playerNumber)
        {
             
            var boardTilesList = GameBoard.BoardTiles;

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

            foreach (var tile in Players.ElementAt(playerNumber).Hand)
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

        public int GetPlayerWithLessTilesLeft()
        {
            const int minAmount = 28;
            var playerNumber = -1;
            var equals = 0;

            foreach (var player in Players)
            {
                var tilesAmount = player.Hand.Count;

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
                return (Player)Players.ElementAt(turno);
            return null;
                
        }
        

        public void InitializeTurns()
        {
            PlayerTurn = CalculateStartingPlayer();
        }


        public void NextPlayerTurn()
        {
            PlayerTurn++;
            if (PlayerTurn > Players.Count)
                PlayerTurn = 1;
        }

        #endregion

        #region Private Methods
        private int GetNumberPlayers()
        {
            return Players.Count;
        }

        #endregion
    }
}
