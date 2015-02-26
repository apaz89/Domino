using System;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class MyRamdom:IRandom
    {
        public int GetRandomPosition()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            return rand.Next(1, 25);
        }
    }
}
