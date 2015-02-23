using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Interfaces
{
    public interface IPlayer
    {
        List<Tile> GameTiles { set; get; }
        void AddTileToGame(Tile tile);
        Tile GetMoveValueTitle();
        Tile DestroyTileAtIndex(int index);
        void AddTilesToTilesList(Tile newTile);
        List<Tile> GetPlayersTileList();
    }
}
