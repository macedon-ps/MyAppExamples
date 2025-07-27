using System.IO;

namespace TableOfRecords.Tests.UserProfiles;

/// <summary>
/// Base profile of an employee.
/// </summary>
public class ProfileBasic
{
    /// <summary>
    /// Gets or sets full name of the employee.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets age of the employee.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets mobile phone number of the employee.
    /// </summary>
    public string? Phone { get; set; }

    public override string ToString()
    {
        /*TextWriter originalConsoleOut = Console.Out;

        var result = string.Empty;

        using (var stringWriter = new StringWriter())
        {
            Console.WriteLine($"|{0,21}|{1,5}|{2,8}|", $"{this.FullName}", $"{this.Age}", $"{this.Phone}", $"{Environment.NewLine}");

            result = stringWriter.ToString();

            Console.SetOut(originalConsoleOut);
        }*/

        return $"{this.FullName} {this.Age} {this.Phone}";
    }
}
