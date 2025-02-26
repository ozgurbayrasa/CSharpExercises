using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.DataModels
{
    public record PlanetDTO(
        [property: JsonPropertyName("name")] string name,
        [property: JsonPropertyName("diameter")] string diameter,
        [property: JsonPropertyName("surface_water")] string surface_water,
        [property: JsonPropertyName("population")] string population
    );
}
