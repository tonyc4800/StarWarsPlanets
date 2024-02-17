namespace StarWarsPlanetsAPI.Utilties;

internal interface ITableDisplayGenerator
{
    string Generate<T>(IEnumerable<T> dataSet);
}
