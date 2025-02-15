namespace StarwarsPlanetStatsApi.ApiReader
{
    internal class ApiReader : IApiReader
    {
        public async Task<string> Read(string baseAdress, string requestUri)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseAdress);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
