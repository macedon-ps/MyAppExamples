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

        // найдем свойства типа Т, их количество, имена, ширины в таблице, которые занимают соответствующие данные
        var properties = typeof(T).GetProperties();
        var propertiesNumber = properties.Length;
        var propertiesNames = GetPropertiesNames(properties);
        var propertiesDataWidths = GetPropertiesDataWidths(collection, properties);

        var stringFormat = StringFormat(propertiesNumber, propertiesDataWidths);

        using (writer)
        {
            var simpleRowTable = GetSimpleRowTable(propertiesNumber, propertiesDataWidths);
            var titleRowTable = GetTitleRowTable(propertiesNumber, propertiesDataWidths, propertiesNames);

            var result = new StringBuilder();

            result.AppendLine(simpleRowTable);
            result.AppendLine(string.Format(stringFormat, "Ghbdtn", "hj", "dghjhu"));
            result.AppendLine(simpleRowTable);



            //writer.WriteLine("+---------------------+-----+--------+");
            //writer.WriteLine("|{0,-21}|{1,-5}|{2,-8}|", "FullName", "Age", "Phone", "|");
            //writer.WriteLine("+---------------------+-----+--------+");

            //if (collection.GetType().FullName.Contains("ProfileBasic"))
            //{
            //    writer.WriteLine($"|{0,-21}|{1,5}|{2,-8}|", $"FullName", "Age", "Phone");
            //    writer.WriteLine("+---------------------+-----+--------+");

            //    foreach (var item in collection)
            //    {
            //        writer.WriteLine($"|{0,-21}|{1,5}|{2,-8}|", $"FullName", "Age", "Phone");
            //        writer.WriteLine("+---------------------+-----+--------+");
            //    }
            //}

            var resultStringTable = result.ToString();

            writer.Write(resultStringTable);
        }
    }

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

    private static string GetTitleRowTable(int propertiesNumber, int[] propertiesDataWidths, string[] propertiesNames)
    {
        var titleRow = new StringBuilder();

        for (var i = 0; i < propertiesNumber; i++)
        {
            var str = $"{{{i}, {propertiesDataWidths[i]}}} ";
            titleRow.Append(str);

            if (i == propertiesNumber - 1)
            {
                titleRow.Append(", ");
            }
        }

        for (var i = 0; i < propertiesNumber; i++)
        {
            var str = $"{propertiesNames[i]}";
            titleRow.Append(str);

            if (i != propertiesNumber - 1)
            {
                titleRow.Append(", ");
            }
        }

        var title = titleRow.ToString();
        //var titleData = string.Format(stringFormat, propertiesNames);

        return title;
    }

    private static string[] GetPropertiesNames(PropertyInfo[] properties)
    {
        var propertiesNames = new string[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            propertiesNames[i] = properties[i].Name;
        }

        return propertiesNames;
    }

    private static int[] GetPropertiesDataWidths<T>(ICollection<T> collection, PropertyInfo[] properties)
    {
        int[] propertiesDataWidths = properties
            .Select(p => collection.Select(c => p.GetValue(c)?.ToString()?.Length ?? 0)
            .Max())
            .ToArray();

        return propertiesDataWidths;
    }

    private static string StringFormat(int propertiesNumber, int[] propertiesDataWidths)
    {
        var buildFormat = new StringBuilder();

        for (int i = 0; i < propertiesNumber; i++)
        {
            buildFormat.Append('{').Append($"{i}, -{propertiesDataWidths[i]}").Append(('}')).Append(" ");
        }

        return buildFormat.ToString();
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
