using System;
using System.IO;
using Domino.Logic.Intefaces;

namespace Domino.Logic.Implementations
{
    public class Statistics:IStatistics
    {
        public bool WriteStatistics(int player)
        {
            const string fileName = "Stadistics.bin";
            var player1 = 0;
            var player2 = 0;

            if (File.Exists(fileName))
            {
                using (var reader = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    player1 = reader.ReadInt32();
                    player2 = reader.ReadInt32();
                }
            }

            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                switch (player)
                {
                    case 1:
                        writer.Write(player1 + 1);
                        writer.Write(player2);
                        return true;
                    case 2:
                        writer.Write(player1);
                        writer.Write(player2 + 1);
                        return true;
                }
            }
            return false;
        }
    }
}
