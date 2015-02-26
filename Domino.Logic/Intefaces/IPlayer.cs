using System.Collections.Generic;
using Domino.Logic.Implementations;

namespace Domino.Logic.Intefaces
{
    public interface IPlayer
    {
        List<Tile> Hand { set; get; }
        int PlayerNumber { get; set; }
        int Points { set; get; }
        Tile GetMostValuableSumTileInHand();
        void AddTileToPlayerHand(Tile popTileFromStock);

        Tile PopTileAtIndex(int index);
    }
}
