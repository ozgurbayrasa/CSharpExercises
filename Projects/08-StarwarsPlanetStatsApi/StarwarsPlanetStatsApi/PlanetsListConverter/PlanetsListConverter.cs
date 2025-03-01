using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.Api;
using StarwarsPlanetStatsApi.DataModels;


namespace StarwarsPlanetStatsApi.PlanetsListConverter
{
    public class PlanetsListConverter
    {
        public static IReadOnlyList<PlanetDTO> ConvertToPlanetsList(string stringResponse)
        {
            var rootResponse = JsonSerializer.Deserialize<StarwarsPlanetAPIRootResponse>(stringResponse);

            if(rootResponse is not null)
            {
                return rootResponse.Planets;
            }

            throw new NullReferenceException();
            
        }
    }
}
