using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.Api
{
    internal interface IApiReader
    {
        public Task<string> Read(string requestUri);
    }
}
