using System.Collections.Generic;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class Board : IBoard
    {
        public List<Tile> BoardTiles { get; set; }
        public Board()
        {
            BoardTiles=new List<Tile>();

        }

        
        public void AddTileToBoard(Tile tile)
        {
            BoardTiles.Add(tile);
        }
    }
}
