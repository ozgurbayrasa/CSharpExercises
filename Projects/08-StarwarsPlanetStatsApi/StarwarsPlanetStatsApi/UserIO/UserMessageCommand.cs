using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.UserIO
{
    internal class UserMessageCommand : IUserIO
    {
        public void PrintInfoMessage()
        {
            Console.WriteLine();
            Console.WriteLine("The statistics of which property would you like to see?");
            Console.WriteLine("population\ndiameter\nsurface water");
        }

        public string GetPropertyFromUser()
        {
            bool isValidInput = false;
            string userResponse = string.Empty;
            while (!isValidInput)
            {
                userResponse = Console.ReadLine();

                if (userResponse is null)
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                if(userResponse.Contains("population") || userResponse.Contains("diameter") || userResponse.Contains("surface water"))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
                
            }

            return userResponse;
        }

        
    }
}
