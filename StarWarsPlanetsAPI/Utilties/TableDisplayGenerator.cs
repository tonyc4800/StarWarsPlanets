using System.Text;

namespace StarWarsPlanetsAPI.Utilties;

internal class TableDisplayGenerator : ITableDisplayGenerator
{
    public string Generate<T>(IEnumerable<T> dataSet)
    {
        const int width = 16;
        var tableStringBuilder = new StringBuilder();
        var properties = typeof(T).GetProperties();

        var tableHeader = properties.Select(property => $"{property.Name,-width}|");
        tableStringBuilder.AppendLine(string.Join("", tableHeader));
        tableStringBuilder.AppendLine(new string('-', properties.Length * (width + 1)));

        // Table body
        foreach (var item in dataSet)
        {
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(item);
                if (propertyValue == null)
                {
                    propertyValue = "";
                }
                tableStringBuilder.Append($"{propertyValue,-width}|");
            }
            tableStringBuilder.Append(Environment.NewLine);
        }

        return tableStringBuilder.ToString();
    }
}
