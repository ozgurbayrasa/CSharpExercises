using StarwarsPlanetStatsApi.DataModels;
using StarwarsPlanetStatsApi.UserIO;

namespace StarwarsPlanetStatsApi.Statistics
{
    internal class PlanetsStatisticsAnalyzer : IPlanetStatisticsAnalyzer
    {

        private readonly IUserIO _userIO;

        private readonly Dictionary<string, Func<PlanetDTO, long>> _propertyNamesToSelectorFunc = new()
        {
            ["population"] = planet => planet.Population.Equals("unknown") ? 0 : long.Parse(planet.Population),
            ["diameter"] = planet => long.Parse(planet.Diameter),
            ["surface water"] = planet => planet.SurfaceWater.Equals("unknown") ? 0 : long.Parse(planet.SurfaceWater),
        };


        public PlanetsStatisticsAnalyzer(IUserIO userIo)
        {
            _userIO = userIo;
        }

        public void Analyze(IEnumerable<PlanetDTO> planetsList)
        {
            string selectedProperty = _userIO.GetPropertyFromUser(_propertyNamesToSelectorFunc.Keys);

            long maxValue = planetsList.Max(_propertyNamesToSelectorFunc[selectedProperty]);
            long minValue = planetsList.Min(_propertyNamesToSelectorFunc[selectedProperty]);

            _userIO.PrintStatsMessage(minValue, maxValue, selectedProperty);
        }


    }
}
