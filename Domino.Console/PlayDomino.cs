using System;
using Domino.Logic.Implementations;
using Domino.Logic.Intefaces;

namespace Domino.Console
{
    public class PlayDomino
    {
        private readonly IDominoGame _myDomino;

        private readonly IStock _stock;

        private readonly IPlayer _currentPlayer;

        public PlayDomino(int numberOfPlayers)
        {
            _myDomino=new DominoGame();
            _stock=new Stock();
            _stock.Shuffle(15);
            _myDomino.InitializePlayers(numberOfPlayers);
            _myDomino.InitializeTurns();
            _currentPlayer = _myDomino.GetPlayerAtTurn(_myDomino.PlayerTurn);
        }

        public PlayDomino(IDominoGame myDominoGame,IStock stock,int numberOfPlayers)
        {
            _myDomino = myDominoGame;
            _stock = stock;
            _stock.Shuffle(15);
            _myDomino.InitializePlayers(numberOfPlayers);
            _myDomino.InitializeTurns();
            _currentPlayer= _myDomino.GetPlayerAtTurn(_myDomino.PlayerTurn);
        }

        public void ImprimirJuego()
        {
            System.Console.Clear();

            System.Console.WriteLine("\n\n\t\tBIENVENIDO A DOMINO OVERFLOW");
            System.Console.WriteLine("\nTURNO: Jugador " + _currentPlayer.PlayerNumber);
            

            foreach (var player in _myDomino.Players)
            {
                System.Console.WriteLine("\nJugador" + _currentPlayer.PlayerNumber);
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

        public void PegungarMovimiento()
        {
            System.Console.WriteLine();

            System.Console.Write("Jugador "+_currentPlayer.PlayerNumber+", Indique la pieza a mover de su mano(0 para pieza del pozo): ");
            var posicionPieza = System.Console.ReadLine();

            if (string.IsNullOrEmpty(posicionPieza)) return;
            _myDomino.PlaceTileOnBoard(_currentPlayer.PlayerNumber, _myDomino.GameBoard.BoardTiles.Count, Int32.Parse(posicionPieza));
            System.Console.WriteLine("Jugador " + _currentPlayer.PlayerNumber + " tomo una pieza del pozo");
        }

        public void MostrarEstadisticas()
        {
            //_myDomino;
            //Console.ReadKey();
        }



    }
}
