using StarWarsPlanetsAPI.ConsoleInteraction;
using StarWarsPlanetsAPI.Utilties;

namespace StarWarsPlanetsAPI.SWPApp;

internal class SWPapp
{
    private ISWConsoleInteraction _swConsoleInteraction;
    private IPlanetData _planetDataAccess;
    private ITableDisplayGenerator _tableDisplayGenerator;

    public SWPapp(ISWConsoleInteraction swInteraction, IPlanetData planetDataAccess, ITableDisplayGenerator tableDisplayGenerator)
    {
        _swConsoleInteraction = swInteraction;
        _planetDataAccess = planetDataAccess;
        _tableDisplayGenerator = tableDisplayGenerator;
    }

    public void Run()
    {
        var planetData = _planetDataAccess.GetPlanetData();
        _swConsoleInteraction.Show(_tableDisplayGenerator.Generate(planetData));
        var userFilterOption = _swConsoleInteraction.ReadValidOption();
        var filteredData = _planetDataAccess.Filter(planetData, userFilterOption);
        _swConsoleInteraction.Show(filteredData);
        _swConsoleInteraction.Exit();
    }
}
