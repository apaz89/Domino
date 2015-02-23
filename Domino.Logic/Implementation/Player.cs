using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Implementation
{
    public class Player
        {
            private List<Tile> _tilesList=new List<Tile>();

            public void AddTilesToTilesList(Tile newTile)
            {
                _tilesList.Add(newTile);
            }

            public List<Tile> GetPlayersTileList()
            {
                return _tilesList;
            }

        }
}
