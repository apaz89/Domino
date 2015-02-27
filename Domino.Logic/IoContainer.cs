using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Intefaces;
using Domino.Logic.Implementations;
using Autofac;

namespace Domino.Logic
{
    public class IoContainer
    {
        public static IContainer ContainerRepo()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<Tile>().As<ITile>();
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<Tile>().As<ITile>();
            builder.RegisterType<Board>().As<IBoard>();
            builder.RegisterType<DominoGame>().As<IDominoGame>();
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<MyRamdom>().As<IRandom>();
            builder.RegisterType<Statistics>().As<IStatistics>();
            builder.RegisterType<Stock>().As<IStock>();
            IContainer myTile = builder.Build();


            return myTile;
        }
    }
}
