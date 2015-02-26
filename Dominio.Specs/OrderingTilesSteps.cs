using System.Collections.Generic;
using System.Linq;
using Domino.Logic.Implementations;
using Domino.Logic.Intefaces;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
    [Binding]
    public class OrderingTilesSteps
    {
        
        private readonly MyStockBdd _myStock= new MyStockBdd();

        [Given(@"I have a collection")]
        public void GivenIHaveACollection(Table table)
        {
            var stockInitial = table.CreateSet<Tile>();
            ScenarioContext.Current.Add("Stock", stockInitial);
        }

        [When(@"The game start")]
        public void WhenTheGameStart()
        {
            ScenarioContext.Current.Add("NewStock",_myStock.Shuffle(3));
        }

        [Then(@"It should not match")]
        public void ThenItShouldNotMatch(Table table)
        {
            var stockMixed = ScenarioContext.Current["NewStock"] as IEnumerable<Tile>;
            Assert.IsFalse(table.ToProjection<Tile>().SequenceEqual(stockMixed.ToProjection()) );
        }
    }

    public interface IRandom
    {
        int GetRandomPosition();
    }

    internal class TileDomino
    {
        public int Head { get; set; }

        public int Tail { get; set; }

    }

    internal class MyStockBdd
    {
        private delegate int RandomPositionDelegate();

        public List<Tile> Shuffle(int repeats)
        {
            var tiles = ScenarioContext.Current["Stock"] as List<Tile>;

           var random = MockRepository.GenerateMock<IRandom>();
            var randomSerie = new[] { 3, 0, 4, 7, 10, 12 };
            var randomSerieIndex = 0;

            RandomPositionDelegate randomFunction = () =>
            {
                var value = randomSerie[randomSerieIndex];
                randomSerieIndex++;
                return value;
            };
            random.Stub(x => x.GetRandomPosition()).Do((randomFunction));


            for (var i = 0; i < repeats; i++)
            {
                var posTile1 = random.GetRandomPosition();
                var posTile2 = random.GetRandomPosition();

                if (tiles != null)
                {
                    var temp = tiles[posTile1];
                    tiles[posTile1] = tiles.ElementAt(posTile2);
                    tiles[posTile2] = temp;
                }
            }
            return tiles;
        }
    }
}
