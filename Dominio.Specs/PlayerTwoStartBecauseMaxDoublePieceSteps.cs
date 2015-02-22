using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
    [Binding]
    public class PlayerTwoStartBecauseMaxDoublePieceSteps
    {
        [Given(@"Player one has a collection")]
        public void GivenPlayerOneHasACollection(Table table)
        {
            var playerOnePieces = table.CreateSet<TileDomino>();
            ScenarioContext.Current.Add("Player1Hand",playerOnePieces);
        }

        [Given(@"Player two has a collection")]
        public void GivenPlayerTwoHasACollection(Table table)
        {
            var playerTwoPieces = table.CreateSet<TileDomino>();
            ScenarioContext.Current.Add("Player2Hand", playerTwoPieces);
        }

        [When(@"Player two has the max double piece")]
        public void WhenPlayerTwoHasTheMaxDoublePiece()
        {

            TileDomino maxDoublePiece;

            var player1Hand= ScenarioContext.Current["Player1Hand"] as List<TileDomino>;
            var player2Hand= ScenarioContext.Current["Player2Hand"] as List<TileDomino>;



            var maxDoublePiecePlayer1 = PlayerHand.GetMaxDoublePiecePlayer(player1Hand);
            var maxDoublePiecePlayer2 = PlayerHand.GetMaxDoublePiecePlayer(player2Hand);

            if (maxDoublePiecePlayer1.Head < maxDoublePiecePlayer2.Head &&
                maxDoublePiecePlayer1.Tail < maxDoublePiecePlayer2.Tail)
            {
                maxDoublePiece = maxDoublePiecePlayer2;
            }
            else
            {
                maxDoublePiece = maxDoublePiecePlayer1;
            }

            ScenarioContext.Current.Add("MaxDoubleTail", maxDoublePiece);

            
        }

        [Then(@"The player two start the game")]
        public void ThenThePlayerTwoStartTheGame()
        {
            var maxdoubleTail = ScenarioContext.Current["MaxDoubleTail"] as TileDomino;
            var player2Hand = ScenarioContext.Current["Player2Hand"] as List<TileDomino>;
            CollectionAssert.Contains(player2Hand,maxdoubleTail,"Player two has not the max double tail");
        }
    }

    internal class PlayerHand
    {
        public static TileDomino GetMaxDoublePiecePlayer(List<TileDomino> playerHand)
        {
            var currentMaxDoubleTile = new TileDomino();
            foreach (var t in playerHand)
            {
                if (t.Head == t.Tail)
                {
                    if (currentMaxDoubleTile.Head<t.Head && currentMaxDoubleTile.Tail<t.Tail)
                    {
                        currentMaxDoubleTile = t;
                    }
                }
            }
            return currentMaxDoubleTile;
        }

    }

}
