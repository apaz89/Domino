using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Board:IBoard
    {
        public List<Tile> BoardTiles { get; set; }
        public void AddTileToBoard(Tile tile)
        {
            BoardTiles.Add(tile);
        }
    }
}
