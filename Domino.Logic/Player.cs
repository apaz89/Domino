using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Player:IPlayer
    {
        public List<Tile> Hand { get; set; }
        public int PlayerNumber { get; set; }
        public int Points { get; set; }

        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
            Points = 0;
        }
        
        public void TakeTile(Tile tile)
        {
            throw new NotImplementedException();
        }

        public Tile GetMostValuableTileInHand()
        {
            var tempDoubleTile = new Tile(-1, -1);
            var tempSumTile = new Tile(-1,-1);

            foreach (var tile in Hand)
            {
                if (tile.IsDoubleTile)
                {
                    if (tile.Head > tempDoubleTile.Head)
                        tempDoubleTile = tile;
                }
                else
                {
                    int newSum = tile.Head + tile.Tail;
                    int originalSum = tempSumTile.Head + tempSumTile.Tail;

                    if (newSum > originalSum)
                        tempSumTile = tile;
                }

            }

            if (tempDoubleTile.IsDoubleTile)
                return tempDoubleTile;
            return tempSumTile;
        }
    }
}
