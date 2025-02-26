using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.UserIO
{
    internal interface IUserIO
    {
        public void PrintInfoMessage();
        public string GetPropertyFromUser();

        public void PrintStatistics(string userRespose, IEnumerable<PlanetDTO> planetList);
    }
}
