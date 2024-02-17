namespace StarWarsPlanetsAPI.Api;

internal interface IApiDataReader
{
    Task<string> Read(string baseAddress, string uri);
}
