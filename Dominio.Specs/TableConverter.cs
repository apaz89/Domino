using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic;
using TechTalk.SpecFlow;

namespace Dominio.Specs
{
    public class TableConverter
    {
        public static List<Tile> TableToList(Table table)
        {
            var tileList = new List<Domino.Logic.Tile>();

            foreach (TableRow row in table.Rows)
            {
                tileList.Add(new Tile(Convert.ToInt32(row["Head"]), Convert.ToInt32(row["Tail"])));
            }
            return tileList;
        }
    }
}
