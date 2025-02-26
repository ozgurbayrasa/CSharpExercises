using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.TablePrinter
{
    internal class UniversalTablePrinter : ITablePrinter
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
                    Console.Write(planet.name.PadRight(padLength) + '|');
                    Console.Write(planet.diameter.PadRight(padLength) + '|');
                    if(!planet.surface_water.Equals("unknown"))
                    {
                        Console.Write(planet.surface_water.PadRight(padLength) + '|');
                    }
                    else
                    {
                        Console.Write(" ".PadRight(padLength) + '|');
                    }
                    if(!planet.population.Equals("unknown"))
                    {
                        Console.Write(planet.population.PadRight(padLength) + '|');
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
