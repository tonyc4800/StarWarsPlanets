namespace StarWarsPlanetsAPI.Api;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string uri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);          

        var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}