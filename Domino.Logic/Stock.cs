using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domino.Logic
{
    public class Stock
    {
        private IRandom _random;

        public List<Tile> Tiles { get; set; }

        public Stock(IRandom random)
        {
            _random = random;
            Tiles = GetInitialSetOfTiles();
        }

        public static List<Tile> GetInitialSetOfTiles()
        {
            List<Tile> initialTiles = new List<Tile>();
            
            const int maxValue = 6;
            for (int headValue = 0; headValue <= maxValue; headValue++)
            {
                for (int tailValue = headValue; tailValue <= maxValue; tailValue++)
                {
                    var currentTile = new Tile() {Head = headValue, Tail = tailValue};
                    initialTiles.Add(currentTile);
                }
            }

            return initialTiles;
        }

        public void Shuffle(int swapsAmount)
        {
            for (int i = 0; i < swapsAmount; i++)
            {
                SwapTilesRandomly();
            }
        }

        public Tile PopFromStock()
        {
            var tile = Tiles.ElementAt(0);
            Tiles.RemoveAt(0);
            return tile;
        }

        private void SwapTilesRandomly()
        {
            int posTile1 = _random.GetRandomPosition();
            int posTile2 = _random.GetRandomPosition();

            var temp = Tiles[posTile1];
            Tiles[posTile1] = Tiles[posTile2];
            Tiles[posTile2] = temp;
        }

            public Tile PopTileFromStock()
            {
                var tile = Tiles.ElementAt(0);
                Tiles.RemoveAt(0);
                return tile;
            }
    }
}