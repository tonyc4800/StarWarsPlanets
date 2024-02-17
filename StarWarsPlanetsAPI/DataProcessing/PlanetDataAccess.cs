using StarWarsPlanetsAPI.Api;
using StarWarsPlanetsAPI.DTO;
using StarWarsPlanetsAPI.Model;
using StarWarsPlanetsAPI.SWPApp;
using System.Text.Json;

namespace StarWarsPlanetsAPI;

internal class PlanetDataAccess : IPlanetData
{
    private readonly string _baseAddress;
    private readonly string _uri;
    private IApiDataReader _apiReader;
    private readonly IOptionsRegistry _optionsRegistry;

    public PlanetDataAccess(IApiDataReader apiReader, string baseAddress, string uri, IOptionsRegistry filterOptions)
    {
        _apiReader = apiReader;
        _baseAddress = baseAddress;
        _uri = uri;
        _optionsRegistry = filterOptions;
    }

    public List<Planet> GetPlanetData()
    {
        try
        {
            var planetDataJson = _apiReader.Read(_baseAddress, _uri).Result;
            var plantDTO = JsonSerializer.Deserialize<Root>(planetDataJson);
            var planetData = plantDTO!.results.Select(planet => new Planet(planet));

            return new List<Planet>(planetData);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API retrival was unsuccessful. " + "Exception message: " + ex.Message);
            throw;
        }

    }
        
    public string Filter(IEnumerable<Planet> planetData, string userOption)
    {
        var filterOption = _optionsRegistry[userOption];
        var maxPlanet = planetData.MaxBy(filterOption);
        var minPlanet = planetData.MinBy(filterOption);        

        var maxPlanetString = $"Max {userOption} is: {filterOption(maxPlanet)} ({maxPlanet.Name})";
        var minPlanetString = $"Min {userOption} is: {filterOption(minPlanet)} ({minPlanet.Name})";

        return $"{maxPlanetString}{Environment.NewLine}{minPlanetString}";
    }

}
