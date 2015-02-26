using System;
using System.IO;
using Domino.Logic.Implementations;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dominio.Specs
{
    [Binding]
    public class SpecStatisticsSteps
    {
        [Given(@"I have the score of the players")]
        public void GivenIHaveTheScoreOfThePlayers(Table table)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"Write Player Statictics '(.*)' on the screen")]
        public void ThenWritePlayerStaticticsOnTheScreen(string p0)
        {
            var writer = new BinaryWriter((File.Open("Statistics.bin", FileMode.Create)));
            using (writer)
            {
                foreach (var i in p0)
                {
                    writer.Write(i);
                    //vamos a leer el archivo primero para ver que tiene
                    try
                    {
                        var letter = 0;
                        var stream = new FileStream("Statistics.bin", FileMode.Open, FileAccess.Read);
                        var reader = new BinaryReader(stream);

                        while (letter != -1)
                        {
                            letter = reader.Read();
                            if (letter != -1) Console.Write((char)letter);
                        }
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Error, no tiene nada el archivo");
                    }
                }
            }
            var file = new Statistics();
            Assert.IsTrue(file.WriteStatistics(1), "El jugador 2 no pudo escribir estadisticas");
            Assert.IsTrue(file.WriteStatistics(2), "El jugador 1 no pudo escribir estadisticas");
        }
    }
}
