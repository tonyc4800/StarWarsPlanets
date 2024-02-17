using StarWarsPlanetsAPI.Model;

namespace StarWarsPlanetsAPI.SWPApp;

internal interface IOptionsRegistry : IEnumerable<string>
{
    Func<Planet, long?> this[string key] { get; }
}
