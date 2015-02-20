using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
    [Binding]
    public class PlayerSteps
        {
            private List<Tile> _stock;
            private List<Tile> _playerTilesList;
            
        //[Given(@"a board")]
        //public void GivenABoard()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        [Given(@"a stock")]
        public void GivenAStock(Table table)
        {
            _stock = table.CreateSet<Tile>().ToList();
        }
        
        [Given(@"Player (.*) doesn't have a matching piece")]
        public void GivenPlayerDoesnTHaveAMatchingPiece(int p0, Table table)
        {
            _playerTilesList = table.CreateSet<Tile>().ToList();
        }

        [Then(@"add (.*) tile to Player (.*) list of tiles")]
        public void ThenAddTileToPlayerListOfTiles(int p0, int p1)
        {
            for (int i = 0; i < p0; i++)
            {
                _playerTilesList.Add(_stock.ElementAt(0));
            }
            
        }

        [Then(@"remove (.*) tile from stock")]
        public void ThenRemoveTileFromStock(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                _stock.RemoveAt(0);
            }
        }


    }

    internal class Tile
        {
            public int Head { get; set; }
            public int Tail { get; set; }
        }
}
