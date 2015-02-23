using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Domino.Logic
{
    public class Tile:IComparable
    {

        public Tile(int tileHead, int tileTail)
        {
            this.Head = tileHead;
            this.Tail = tileTail;
            IsNumeric = false;
        }

        public Tile()
        {
            throw new NotImplementedException();
        }

        public void Swap()
        {
            var temp = Head;
            Head = Tail;
            Tail = temp;
        }


        public bool IsNumeric { get; set; }

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

       
    }
}