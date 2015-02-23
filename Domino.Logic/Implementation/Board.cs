using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic.Implementation
{
    public class Board
        {
            
            private List<Tile> _boardTilesList=new List<Tile>();

            public void AddTileToBoard(Tile newTile)
            {
                _boardTilesList.Add(newTile);
            }

            public List<Tile> GetBoardTiles()
            {
                return _boardTilesList;
            }
        }

}
