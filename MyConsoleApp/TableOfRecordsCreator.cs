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

        var isRightPositionDataArray = GetRightPositionDataArray(properties);

        var dataColumnsWidthsArrey = GetPropertiesDataWidths(collection, properties);

        var propertiesNames = GetPropertiesNames(properties, isRightPositionDataArray);
                
        int intentRight = 1;
        int intentLeft = 1;
        var chanchedDataColumsWidthsArrey = GetChanchedDataColumnsWidths(dataColumnsWidthsArrey, intentRight, intentLeft);

        // format string for composite formatting
        var stringFormat = StringFormat(propertiesNumber, chanchedDataColumsWidthsArrey, isRightPositionDataArray);

        using (writer)
        {
            var simpleRowTable = GetSimpleRowTable(propertiesNumber, chanchedDataColumsWidthsArrey);
            
            var result = new StringBuilder();

            // Header of table
            result.AppendLine(simpleRowTable);
            result.AppendLine(string.Format(stringFormat, propertiesNames));
            result.AppendLine(simpleRowTable);

            foreach (var item in collection)
            {
                var data = GetPropertiesValues(properties, item, isRightPositionDataArray);

                // Body of table
                result.AppendLine(string.Format(stringFormat, data));
                result.AppendLine(simpleRowTable);
            }

            var resultStringTable = result.ToString();

            writer.Write(resultStringTable);
        }
    }

    /// <summary>
    /// Method for getting an array of boolean values to arrange values on the right or left side of a column.
    /// </summary>
    /// <param name="properties">Type's properties.</param>
    /// <returns>Array of boolean values to arrange values on the right or left side of a column.</returns>
    private static bool[] GetRightPositionDataArray(PropertyInfo[] properties)
    {
        var isRightPositionDataArray = new bool[properties.Length];

        for (int i = 0; i < properties.Length; i++) 
        {
            if (properties[i].PropertyType == typeof(int) || properties[i].PropertyType == typeof(double) || properties[i].PropertyType == typeof(DateTime)) 
            {
                isRightPositionDataArray[i] = true;
            }
            else 
            {
            isRightPositionDataArray[i] = false;
            }
        }

        return isRightPositionDataArray;
    }

    /// <summary>
    /// Method for changing table column widths by adding paddings.
    /// </summary>
    /// <param name="dataColumnsWidthsArrey">Array of initial table column widths.</param>
    /// <param name="intentRight">Right indent.</param>
    /// <param name="intentLeft">Lift indent.</param>
    /// <returns>Array of result table column widths.</returns>
    private static int[] GetChanchedDataColumnsWidths(int[] dataColumnsWidthsArrey, int intentRight = 1, int intentLeft = 1)
    {
        var changedColumnsWidthsArrey = new int[dataColumnsWidthsArrey.Length];
        for (int i = 0; i < dataColumnsWidthsArrey.Length; i++) 
        {
            changedColumnsWidthsArrey[i] = dataColumnsWidthsArrey[i] + intentRight + intentLeft;
        }

        return changedColumnsWidthsArrey;
    }

    /// <summary>
    /// Method for creating an array of strings with type property names.
    /// </summary>
    /// <param name="properties">Type's properties.</param>
    /// <returns>Array of strings with type property names.</returns>
    private static string[] GetPropertiesNames(PropertyInfo[] properties, bool[] isRightPositionDataArray)
    {
        var propertiesNames = new string[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            propertiesNames[i] = isRightPositionDataArray[i]
            ? properties[i].Name.PadRight(properties[i].Name.Length + 1)
            : properties[i].Name.PadLeft(properties[i].Name.Length + 1);
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
        // we determine the width of each column with indents
        var propertiesDataWidths = new int[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            propertiesDataWidths[i] = properties[i].Name.Length;
        }

        foreach (var item in collection)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                var value = properties[i].GetValue(item)?.ToString() ?? string.Empty;
                propertiesDataWidths[i] = Math.Max(propertiesDataWidths[i], value.Length);
            }
        }

        return propertiesDataWidths;
    }

    /// <summary>
    /// Method for creating a format string for composite formatting.
    /// </summary>
    /// <param name="propertiesNumber">Numbers of properties of type.</param>
    /// <param name="propertiesDataWidths">Widths for table's columns.</param>
    /// <returns>Format string for composite formatting.</returns>
    private static string StringFormat(int propertiesNumber, int[] propertiesDataWidths, bool[] isRightPositionDataArray)
    {
        var buildFormat = new StringBuilder();

        for (int i = 0; i < propertiesNumber; i++)
        {
            buildFormat.Append('|').Append('{').Append($"{i}, ");

            if (!isRightPositionDataArray[i]) 
            {
                buildFormat.Append('-');
            }

            buildFormat.Append($"{propertiesDataWidths[i]}").Append(('}'));

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
    private static object[] GetPropertiesValues<T>(PropertyInfo[] properties, T? item, bool[] isRightPositionDataArray)
    {
        var valuesList = new List<object>();

        for (int i = 0; i < properties.Length; i++)
        {
            var data = properties[i].GetValue(item, null).ToString();
            var dataString = isRightPositionDataArray[i] 
                ? data.PadRight(data.Length + 1)
                : data.PadLeft(data.Length + 1);
            valuesList.Add(dataString);
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
