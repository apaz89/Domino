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
            Jugar();
        }

        private static void Jugar()
        {
            System.Console.Write("Ingrese cantidad de jugadores:  ");
            var numberOfPlayers = System.Console.ReadLine();

            if (numberOfPlayers != null)
            {
                var juegoDomino = new PlayDomino(Int32.Parse(numberOfPlayers));
                var continuar = true;

                do
                {
                    juegoDomino.ImprimirJuego();
                    juegoDomino.PegungarMovimiento();
                    juegoDomino.ImprimirJuego();

                    System.Console.Write("\nDesea continuar jugando? (S/N) ");
                    var respuesta = System.Console.ReadLine();
                    if (!string.IsNullOrEmpty(respuesta))
                    {
                        if ((!respuesta[0].Equals('N') && !respuesta[0].Equals('n')))
                            continue;
                        continuar = false;
                        juegoDomino.MostrarEstadisticas();
                    }
                    else
                    {
                        System.Console.Clear();
                    }
                } while (continuar);
            }
        }
    }
}
