using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.Statistics
{
    public interface IPlanetStatisticsAnalyzer
    {
        void Analyze(IEnumerable<PlanetDTO> planetsList);
    }
}
