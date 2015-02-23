using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Interfaces
{
    public interface IPlayer
    {
        List<Tile> Hand { set; get; }
        int PlayerNumber { get; set; }
        int Points { set; get; }
        void TakeTile(Tile tile);
        Tile GetMostValuableTileInHand();
        //Tile PopTileAtIndex(int index);

        //Stack<KeyValuePair<int, Piece>> GetPieces();
    }
}
