using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsPlanetStatsApi.HTTPClient
{
    internal class HttpClientProvider : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientProvider(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public HttpClient GetClient()
        {
            return _httpClient;
        }
    }
}
