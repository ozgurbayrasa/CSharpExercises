using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.TablePrinter
{
    public class UniversalTablePrinter : ITablePrinter
    {
        private const int padLength = 16;
        private readonly string[] headers = {"Name", "Diameter", "SurfaceWater", "Population" };
        public void Print(IEnumerable<PlanetDTO> planetList)
        {
            foreach(var header in headers)
            {
                Console.Write(header.PadRight(padLength) + '|');
            }
            Console.WriteLine();
            PrintLine();
            foreach(var planet in planetList)
            {
                if(planet != null)
                {
                    Console.Write(planet.Name.PadRight(padLength) + '|');
                    Console.Write(planet.Diameter.PadRight(padLength) + '|');
                    if(!planet.SurfaceWater.Equals("unknown"))
                    {
                        Console.Write(planet.SurfaceWater.PadRight(padLength) + '|');
                    }
                    else
                    {
                        Console.Write(" ".PadRight(padLength) + '|');
                    }
                    if(!planet.Population.Equals("unknown"))
                    {
                        Console.Write(planet.Population.PadRight(padLength) + '|');
                    }
                    else
                    {
                        Console.Write(" ".PadRight(padLength) + '|');
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', (padLength * 4) + 4));
        }
    }
}
