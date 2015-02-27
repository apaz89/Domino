using System;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class Tile:ITile,IComparable
    {
        public int Head { get; set; }
        
        public int Tail{ get; set; }

        public bool HeadTaked { get; set; }
        public bool TailTaked { get; set; }

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

        public void Swap()
        {
            var temp = Head;
            Head = Tail;
            Tail = temp;
        }
    }
}