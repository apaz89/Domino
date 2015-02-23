using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Interfaces
{
    public interface IBoard
    {
        List<Tile> BoardTiles { get; set; }

        void AddTileToBoard(Tile tile);
    }
}
