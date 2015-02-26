using System.Collections.Generic;
using Domino.Logic.Implementations;

namespace Domino.Logic.Intefaces
{
    public interface IBoard
    {
        List<Tile> BoardTiles { get; set; }
        void AddTileToBoard(Tile tile);
    }
}
