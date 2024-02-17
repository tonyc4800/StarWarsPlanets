using StarWarsPlanetsAPI.Model;

namespace StarWarsPlanetsAPI;

internal interface IPlanetData
{
    string Filter(IEnumerable<Planet> PlanetData, string filter);
    List<Planet> GetPlanetData();
}
