using System.Collections.Generic;
using Domino.Logic.Implementations;

namespace Domino.Logic.Intefaces
{
    public interface IDominoGame
    {
        int GetMaxDoublePiecePlayer();
        int PlayerTurn { get; set; }

        List<IPlayer> Players { get; set; }

        IBoard GameBoard { get; set; }

        void InitializePlayers(int numberOfPlayers);

        void InitializePlayersHand(int amountOfTilesForEachPlayer);

        void AddPlayer(IPlayer player);

        void InitializeTurns();

        int CalculateStartingPlayer();

        void AssignHandWinner();
        //void AssignHandWinner(int predeterminedStarter);
        void PlaceTileOnBoard(int playerNumber, int numberOfTilesOnBoard, int tileToPlace);
        bool ValidateMovement(int playerNumber, int numberOfTilesOnBoard, int tileToPlace);

        bool PlayerHasMatchingPiece(int playerNumber);

        int GetPlayerWithLessTilesLeft();

        Player GetPlayerAtTurn(int turno);

        void Move(int positionGameTiles, int positionBoard);

        void NextPlayerTurn();


    }
}
