using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.DataModels
{
    public readonly record struct PlanetDTO(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("diameter")] string Diameter,
        [property: JsonPropertyName("surface_water")] string? SurfaceWater,
        [property: JsonPropertyName("population")] string? Population
    );
}
