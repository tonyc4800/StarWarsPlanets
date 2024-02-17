using StarWarsPlanetsAPI.DTO;

namespace StarWarsPlanetsAPI.Model;

internal struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? Surfacewater { get; }
    public long? Population { get; }

    public Planet(string name, int diameter, int surfaceWater, long? population)
    {
        Name = name;
        Diameter = diameter;
        Surfacewater = surfaceWater;
        Population = population;
    }

    public Planet(Result rootResult)
    {
        if (!int.TryParse(rootResult.diameter, out int diameter))
        {
            throw new InvalidOperationException("rootResult could not be converted to Planet. String to int converstion failure.");
        }

        int? surfaceWater = null;
        if (int.TryParse(rootResult.surface_water, out int sw))
        {
            surfaceWater = sw;
        }

        long? population = null;
        if (long.TryParse(rootResult.population, out long pop))
        {
            population = pop;
        }

        Name = rootResult.name;
        Diameter = diameter;
        Surfacewater = surfaceWater;
        Population = population;
    }
}
