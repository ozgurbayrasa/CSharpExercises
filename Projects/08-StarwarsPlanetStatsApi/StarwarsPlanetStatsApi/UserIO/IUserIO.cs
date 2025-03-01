using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.UserIO
{
    public interface IUserIO
    {
        public void PrintInfoMessage();

        public void PrintStatsMessage(long minValue, long maxValue, string selectedProperty);
        public string GetPropertyFromUser(IEnumerable<string> propertiesList);

    }
}
