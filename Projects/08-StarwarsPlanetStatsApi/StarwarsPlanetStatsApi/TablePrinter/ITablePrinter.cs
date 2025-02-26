using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarwarsPlanetStatsApi.DataModels;

namespace StarwarsPlanetStatsApi.TablePrinter
{
    internal interface ITablePrinter
    {
        public void Print(IEnumerable<PlanetDTO> enumarable);
    }
}
