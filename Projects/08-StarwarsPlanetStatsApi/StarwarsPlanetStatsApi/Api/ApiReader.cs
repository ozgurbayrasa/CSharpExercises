using System.Net.Http;
using StarwarsPlanetStatsApi.HTTPClient;

namespace StarwarsPlanetStatsApi.Api
{
    internal class ApiReader : IApiReader
    {
        private readonly HttpClient _httpClient;

        public ApiReader(IHttpClient httpClientProvider)
        {
            _httpClient = httpClientProvider.GetClient();
        }
        public async Task<string> Read(string requestUri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
