using StarWarsPlanetsAPI.Model;
using System.Collections;

namespace StarWarsPlanetsAPI.SWPApp;

internal class OptionsRegistry : IOptionsRegistry
{
    private readonly Dictionary<string, Func<Planet, long?>> _options = new()
    {
        ["Population"] = planet => planet.Population,
        ["Surface Water"] = planet => planet.Surfacewater,
        ["Diameter"] = planet => planet.Diameter
    };

    public Func<Planet, long?> this[string key] => _options[key];

    public IEnumerator<string> GetEnumerator()
    {
        return _options.Keys.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
