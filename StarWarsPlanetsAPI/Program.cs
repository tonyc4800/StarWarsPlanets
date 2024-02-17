using StarWarsPlanetsAPI;
using StarWarsPlanetsAPI.Api;
using StarWarsPlanetsAPI.ConsoleInteraction;
using StarWarsPlanetsAPI.SWPApp;
using StarWarsPlanetsAPI.Utilties;

const string baseAddress = "https://swapi.dev/api/";
const string uri = "planets";

var filterOptions = new OptionsRegistry();
var swpApp = new SWPapp(
    new SWConsoleInteraction(filterOptions),
    new PlanetDataAccess(new ApiDataReader(), baseAddress, uri, filterOptions),
    new TableDisplayGenerator());

try
{
    swpApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " + "Exception message: " + ex.Message);
}







