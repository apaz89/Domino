using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino.Logic.Intefaces;
using Autofac;

namespace Domino.Logic
{
    public class IoContainer
    {
        public static IContainer ContainerRepo()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ITile>().As<ITile>();

            IContainer myTile = builder.Build();

            return myTile;
        }
    }
}
