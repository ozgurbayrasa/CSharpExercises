using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.DataModels
{
    public record StarwarsPlanetAPIRootResponse(
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("next")] string Next,
        [property: JsonPropertyName("previous")] object Previous,
        [property: JsonPropertyName("results")] IReadOnlyList<PlanetDTO> Planets
    );
}
