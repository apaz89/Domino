using System.Collections.Generic;
using System.Linq;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class Player:IPlayer
    {
        public List<Tile> Hand { get; set; }
        public int PlayerNumber { get; set; }
        public int Points { get; set; }

        public Player()
        {
        }

        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
            Points = 0;
            Hand=new List<Tile>();
        }

        

        public Tile GetMostValuableSumTileInHand()
        {
            var tempSumTile = new Tile {Head = -1,Tail = -1};

            foreach (var tile in Hand)
            {
                var newSum = tile.Head + tile.Tail;
                var originalSum = tempSumTile.Head + tempSumTile.Tail;

                if (newSum > originalSum)
                    tempSumTile = tile;
            }
            return tempSumTile;
        }

        public Tile PopTileAtIndex(int index)
        {
            var tile = Hand.ElementAt(index);
            Hand.RemoveAt(index);
            return tile;
        }


        public void AddTileToPlayerHand(Tile newTile)
        {
            Hand.Add(newTile);
        }
    }
}
