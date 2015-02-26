using System.Collections.Generic;
using Domino.Logic.Implementations;

namespace Domino.Logic.Intefaces
{
    public interface IStock
    {
        List<Tile> GetInitialSetOfTiles();

        List<Tile> Tiles { get; set; }

        Tile PopFromStock();

        void Shuffle(int swapsAmount);


    }
}
