using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Logic.Interfaces
{
    public interface IGame
    {
        List<IPlayer> Players { get; set; }

        void AddPlayer(Player player);
        Player GetPlayer(int playerNumber);
        int CalculateStartingPlayer();
        int GetStartingPlayer();
        void AssignHandWinner();
        void AssignHandWinner(int predeterminedStarter);
    }
}
