using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Console
{
    class Program
    {
        

        static void Main(string[] args)
        {
            PlayDomino play = new PlayDomino(2);
            play.ImprimirJuego();
        }
    }
}
