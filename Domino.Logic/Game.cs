using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Game:IGame
    {
        private int _handWinner;
        public List<IPlayer> Players { get; set; }
        public IBoard GameBoard { get; set; }

        public Game(IBoard board)
        {
            Players = new List<IPlayer>();
            GameBoard = board;
        }
        
        public Game()
        {
            Players = new List<IPlayer>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public Player GetPlayer(int playerNumber)
        {
            return (Player)Players.ElementAt(playerNumber-1);
        }

        public int CalculateStartingPlayer()
        {
            var bestTileInHand = new Tile(-1, -1);

            int playerWithBestHand = 0;
            bool anyDouble = false;

            for (int i = 0; i < Players.Count; i++)
            {
                Tile tile = Players.ElementAt(i).GetMostValuableTileInHand();

                if (tile.IsDoubleTile)
                {
                    if (tile.Head > bestTileInHand.Head)
                    {
                        playerWithBestHand = i;
                        bestTileInHand = tile;
                    }

                    anyDouble = true;
                }
                else
                {
                    if (!anyDouble)
                    {
                        int newSum = tile.Head + tile.Tail;
                        int originalSum = bestTileInHand.Head + bestTileInHand.Tail;

                        if (newSum > originalSum)
                        {
                            playerWithBestHand = i;
                            bestTileInHand = tile;
                        }
                    }
                }
            }

            return playerWithBestHand;
        }

        public int GetStartingPlayer()
        {
            return _handWinner;
        }

        public void AssignHandWinner()
        {
            _handWinner = CalculateStartingPlayer()+1;
        }

        public void AssignHandWinner(int predeterminedStarter)
        {
            _handWinner = predeterminedStarter;
        }

        public void PlaceTileOnBoard(int playerNumber, int numberOfTilesOnBoard, int tileToPlace)
        {

            Tile lastPiece = GameBoard.BoardTiles.ElementAt(numberOfTilesOnBoard-1);
            Tile playerTile = Players.ElementAt(playerNumber - 1).Hand.ElementAt(tileToPlace);

            if (ValidateMovement(playerNumber, numberOfTilesOnBoard,tileToPlace))
            {
                Players.ElementAt(playerNumber - 1).Hand.Remove(playerTile);
                GameBoard.BoardTiles.Add(playerTile);
            }
        }

        public bool ValidateMovement(int playerNumber, int numberOfTilesOnBoard, int tileToPlace)
        {
            Tile lastPiece = GameBoard.BoardTiles.ElementAt(numberOfTilesOnBoard-1);
            Tile playerTile = Players.ElementAt(playerNumber - 1).Hand.ElementAt(tileToPlace);

            if (playerTile.Head == lastPiece.Tail || playerTile.Tail == lastPiece.Tail)
            {
                return true;
            }

            return false;
        }
    }
}
