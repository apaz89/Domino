using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Interfaces;

namespace Domino.Logic.Implementation
{
    public class Player:IPlayer
    {
        public List<Tile> GameTiles { set; get; }

        public Player()
        {
            GameTiles = new List<Tile>();
        }

        public void AddTilesToTilesList(Tile newTile)
        {
            GameTiles.Add(newTile);
        }

        public List<Tile> GetPlayersTileList()
        {
            return GameTiles;
        }
        
        public void AddTileToGame(Tile tile)
        {
            GameTiles.Add(tile);
        }

        public Tile GetMoveValueTitle()
        {
            var uppermostTitle = new Tile(-1, -1);
            var summationTitle = uppermostTitle;
            foreach (var tile in GameTiles)
            {
                if (tile.IsNumeric)
                {
                    if (tile.Head > uppermostTitle.Head)
                        uppermostTitle = tile;
                }
                else
                {
                    var sum1 = tile.Head + tile.Tail;
                    var sum2 = summationTitle.Head + summationTitle.Tail;
                    if (sum1 > sum2)
                        summationTitle = tile;
                }

            }
            if (uppermostTitle.IsNumeric)
                return uppermostTitle;
            return summationTitle;
        }

        public Tile DestroyTileAtIndex(int index)
        {
            var tile = GameTiles.ElementAt(index);
            GameTiles.RemoveAt(index);
            return tile;

        }

        public Tile PopTileAtIndex(int index)
        {
            var tile = GameTiles.ElementAt(index);
            GameTiles.RemoveAt(index);
            return tile;
        }
    }
}
