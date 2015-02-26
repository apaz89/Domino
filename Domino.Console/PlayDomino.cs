using System;
using Domino.Logic.Intefaces;
using Autofac;
using Domino.Logic;
using Domino.Logic.Intefaces;

namespace Domino.Console
{
    public class PlayDomino
    {
        private readonly IDominoGame _myDomino;

        private readonly IStock _stock;

        private readonly IPlayer _currentPlayer;

        private readonly IBoard _myBoard;

        private readonly IStatistics _myStatistics;

        private readonly IRandom _myRandom;

        //private readonly ITile nyTile;

        private static IoContainer _Container { get; set; }

        public PlayDomino(IDominoGame myDominoGame,IStock stock, IPlayer player, IBoard board, IStatistics statistics, IRandom random, ITile tile,int numberOfPlayers)
        {

            _Container = IoContainer.ContainerRepo();
            var myTile = _Container.Resolve<ITile>();

            _myDomino = myDominoGame;
            _stock = stock;
            _currentPlayer = player;
            _myBoard = board;
            _myStatistics = statistics;
            _myRandom = random;
            //_nyTile = tile;
            _stock.Shuffle(15);
            _myDomino.InitializePlayers(numberOfPlayers);
            _myDomino.InitializeTurns();
            _myStatistics= _myDomino.GetPlayerAtTurn(_myDomino.PlayerTurn);
        }

        public void ImprimirJuego()
        {
            System.Console.Clear();

            System.Console.WriteLine("\n\n\t\tBIENVENIDO A DOMINO OVERFLOW");
            System.Console.WriteLine("\nTURNO: Jugador " + _myStatistics.PlayerNumber);
            

            foreach (var player in _myDomino.Players)
            {
                System.Console.WriteLine("\nJugador" + _myStatistics.PlayerNumber);
                var contador = 1;
                foreach (var pair in player.Hand)
                {
                    System.Console.Write(contador + "\t");
                    contador++;
                }

                System.Console.WriteLine();
                foreach (var pair in player.Hand)
                {
                    System.Console.Write("|" + pair.Head + "-" + pair.Tail + "|   ");
                }
                System.Console.WriteLine("\n\n");
            }

            foreach (var tile in _stock.Tiles)
            {
                System.Console.Write("|" + tile.Head+ "-" + tile.Tail+ "|");
            }
        }

        //public void PegungarMovimiento()
        //{
        //    System.Console.WriteLine();

        //    System.Console.Write("Jugador "+_currentPlayer.PlayerNumber+", Indique la pieza a mover de su mano(0 para pieza del pozo): ");
        //    var posicionPieza = System.Console.ReadLine();

        //    if (!string.IsNullOrEmpty(posicionPieza))
        //        if (!_myDomino.PlaceTileOnBoard(_currentPlayer.PlayerNumber,) .PonerPizaEnMesaPorJugador(1, Int32.Parse(posicionPieza1) - 1))
        //        {
        //            System.Console.WriteLine("Jugador 1 tomo una pieza del pozo");
        //        }

        //    break;
        //    switch (_myDomino.PlayerTurn)
        //    {
        //        case 1:
        //            System.Console.Write("Jugador 1, Indique la pieza a mover de su mano(0 para pieza del pozo): ");
        //            var posicionPieza1 = System.Console.ReadLine();

        //            if (!string.IsNullOrEmpty(posicionPieza1))
        //                if (!JuegoDominoJz.PonerPizaEnMesaPorJugador(1, Int32.Parse(posicionPieza1) - 1))
        //                {
        //                    System.Console.WriteLine("Jugador 1 tomo una pieza del pozo");
        //                }

        //            break;
        //        case 2:
        //            System.Console.Write("Jugador 2, Indique la pieza a mover de su mano(0 para pieza del pozo): ");
        //            var posicionPieza2 = System.Console.ReadLine();

        //            if (!string.IsNullOrEmpty(posicionPieza2))
        //                if (!JuegoDominoJz.PonerPizaEnMesaPorJugador(2, Int32.Parse(posicionPieza2) - 1))
        //                {
        //                    System.Console.WriteLine("Jugador 2 tomo una pieza del pozo");
        //                }

        //            break;
        //    }
        //}



    }
}
