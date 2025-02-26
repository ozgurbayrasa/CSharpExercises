using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.HTTPClient
{
    internal interface IHttpClient
    {
        public HttpClient GetClient();
    }
}
