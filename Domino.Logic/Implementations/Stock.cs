using System.Collections.Generic;
using System.Linq;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class Stock : IStock
    {

        private readonly IRandom _random;

        public List<Tile> Tiles { get; set; }

        public Stock()
        {
            Tiles = GetInitialSetOfTiles();
        }

        public Stock(IRandom random)
        {
            _random = random;
            Tiles = GetInitialSetOfTiles();
        }

        public List<Tile> GetInitialSetOfTiles()
        {
            var initialTiles = new List<Tile>();
            
            const int maxValue = 6;
            for (var headValue = 0; headValue <= maxValue; headValue++)
            {
                for (var tailValue = headValue; tailValue <= maxValue; tailValue++)
                {
                    var currentTile = new Tile {Head = headValue, Tail = tailValue};
                    initialTiles.Add(currentTile);
                }
            }

            return initialTiles;
        }

        public Tile PopFromStock()
        {
            var tile = Tiles.ElementAt(0);
            Tiles.RemoveAt(0);
            return tile;
        }

        public void Shuffle(int swapsAmount)
        {
            for (var i = 0; i < swapsAmount; i++)
            {
                SwapTilesRandomly();
            }
        }

        private void SwapTilesRandomly()
        {
            var posTile1 = _random.GetRandomPosition();
            var posTile2 = _random.GetRandomPosition();

            var temp = Tiles[posTile1];
            Tiles[posTile1] = Tiles[posTile2];
            Tiles[posTile2] = temp;
        }

       
    }
}