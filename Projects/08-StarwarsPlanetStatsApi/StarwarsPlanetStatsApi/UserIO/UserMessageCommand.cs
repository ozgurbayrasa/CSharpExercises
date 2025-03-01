using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.UserIO
{
    internal class IOUserCommand : IUserIO
    {
        public void PrintInfoMessage()
        {
            Console.WriteLine();
            Console.WriteLine("The statistics of which property would you like to see?");
            Console.WriteLine("population\ndiameter\nsurface water");
        }

        public string GetPropertyFromUser(IEnumerable<string> validProperties)
        {
            while (true)
            {
                string userResponse = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(userResponse) || !validProperties.Contains(userResponse))
                {
                    PrintInvalidChoiceMessage();
                    continue;
                }

                return userResponse;
            }

        }

        private void PrintInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice! Please enter a valid property: population, diameter, or surface water.");
        }

        public void PrintStatsMessage(long minValue, long maxValue, string selectedProperty)
        {
            Console.WriteLine($"Max {selectedProperty}: {maxValue}");
            Console.WriteLine($"Min {selectedProperty}: {minValue}");
        }
    }
}
