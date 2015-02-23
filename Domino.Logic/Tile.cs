using System;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class Tile:ITile
    {
        public int Head { get; set; }
        public int Tail{ get; set; }

        public bool IsDoubleTile { get; set; }
        
        public void Swap()
        {
            throw new NotImplementedException();
        }

        public Tile(int head, int tail)
        {
            Head = head;
            Tail = tail;
            
            if (head == tail)
            {
                IsDoubleTile = true;
            }
            else
            {
                IsDoubleTile = false;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Tile)
            {
                var tile = (Tile) obj;
                if (tile.Head == this.Head && tile.Tail == this.Tail)
                    return 0;
                else
                {
                    return -1;
                }
            }
            throw new Exception("No are equals");
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }
    }
}