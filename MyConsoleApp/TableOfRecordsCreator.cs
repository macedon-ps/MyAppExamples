using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TableOfRecords;

/// <summary>
/// Presents method that write in table form to the text stream a set of elements of type T.
/// </summary>
public static class TableOfRecordsCreator
{
    /// <summary>
    /// Write in table form to the text stream a set of elements of type T (<see cref="ICollection{T}"/>),
    /// where the state of each object of type T is described by public properties that have only build-in
    /// type (int, char, string etc.)
    /// </summary>
    /// <typeparam name="T">Type selector.</typeparam>
    /// <param name="collection">Collection of elements of type T.</param>
    /// <param name="writer">Text stream.</param>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="collection"/> is null.</exception>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="writer"/> is null.</exception>
    /// <exception cref="ArgumentException">Throw if <paramref name="collection"/> is empty.</exception>
    public static void WriteTable<T>(ICollection<T>? collection, TextWriter? writer)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(writer);
        Guard.ThrowIfNullOrEmpty(collection, nameof(collection));

        // we will find the properties of type T, their number, names, widths in the table, which occupy the corresponding data
        var properties = typeof(T).GetProperties();
        var propertiesNumber = properties.Length;
        var propertiesNames = GetPropertiesNames(properties);
        var propertiesDataWidths = GetPropertiesDataWidths(collection, properties);

        // format string for composite formatting
        var stringFormat = StringFormat(propertiesNumber, propertiesDataWidths);

        using (writer)
        {
            var simpleRowTable = GetSimpleRowTable(propertiesNumber, propertiesDataWidths);
            
            var result = new StringBuilder();

            // Header of table
            result.AppendLine(simpleRowTable);
            result.AppendLine(string.Format(stringFormat, propertiesNames));
            result.AppendLine(simpleRowTable);

            foreach (var item in collection)
            {
                var data = GetPropertiesValues(properties, item);

                // Body of table
                result.AppendLine(string.Format(stringFormat, data));
                result.AppendLine(simpleRowTable);
            }

            var resultStringTable = result.ToString();

            writer.Write(resultStringTable);
        }
    }

    /// <summary>
    /// Method for creating an array of strings with type property names.
    /// </summary>
    /// <param name="properties">Type property.</param>
    /// <returns>Array of strings with type property names.</returns>
    private static string[] GetPropertiesNames(PropertyInfo[] properties)
    {
        var propertiesNames = new string[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            propertiesNames[i] = properties[i].Name;
        }

        return propertiesNames;
    }

    /// <summary>
    /// Method for creating an array of table column widths.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    /// <param name="collection">Collection of items.</param>
    /// <param name="properties">Properties of type.</param>
    /// <returns>Array of table column widths.</returns>
    private static int[] GetPropertiesDataWidths<T>(ICollection<T> collection, PropertyInfo[] properties)
    {
        int[] propertiesDataWidths = properties
            .Select(p => collection.Select(c => p.GetValue(c)?.ToString()?.Length ?? 0)
            .Max())
            .ToArray();

        return propertiesDataWidths;
    }

    /// <summary>
    /// Method for creating a format string for composite formatting.
    /// </summary>
    /// <param name="propertiesNumber">Numbers of properties of type.</param>
    /// <param name="propertiesDataWidths">Widths for table's columns.</param>
    /// <returns>Format string for composite formatting.</returns>
    private static string StringFormat(int propertiesNumber, int[] propertiesDataWidths)
    {
        var buildFormat = new StringBuilder();

        for (int i = 0; i < propertiesNumber; i++)
        {
            buildFormat.Append('|').Append('{').Append($"{i}, -{propertiesDataWidths[i]}").Append(('}'));

            if (i == propertiesDataWidths.Length - 1)
            {
                buildFormat.Append('|');
            }
        }

        return buildFormat.ToString();
    }

    /// <summary>
    /// Method for creating table's row with only symbols.
    /// </summary>
    /// <param name="propertiesNumber">Numbers of properties of type.</param>
    /// <param name="propertiesDataWidths">Array of table column widths.</param>
    /// <returns>Table's row with only symbols.</returns>
    private static string GetSimpleRowTable(int propertiesNumber, int[] propertiesDataWidths)
    {
        var simpleRow = new StringBuilder();

        for (var i = 0; i < propertiesNumber; i++)
        {
            simpleRow.Append('+').Append('-', propertiesDataWidths[i]);

            if (i == propertiesNumber - 1)
            {
                simpleRow.Append('+');
            }
        }

        return simpleRow.ToString();
    }

    /// <summary>
    /// Method for creating an array of type properties values.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    /// <param name="properties">Type's properties.</param>
    /// <param name="item">Item of collection.</param>
    /// <returns>Array of type properties values.</returns>
    private static object[] GetPropertiesValues<T>(PropertyInfo[] properties, T? item)
    {
        var valuesList = new List<object>();

        foreach (var prop in properties)
        {
            var data = prop.GetValue(item, null);
            valuesList.Add(data);
        }

        return valuesList.ToArray();
    }
        
    public static class Guard
    {
        public static void ThrowIfNullOrEmpty<T>(ICollection<T> collection, string paramName)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (collection.Count == 0)
            {
                throw new ArgumentException("Коллекция не должна быть пустой.", paramName);
            }
        }
    }
}
