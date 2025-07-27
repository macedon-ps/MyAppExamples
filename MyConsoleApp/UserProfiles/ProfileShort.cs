namespace TableOfRecords.Tests.UserProfiles;

/// <summary>
/// Short profile of an employee.
/// </summary>
public class ProfileShort
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
    /// Gets or sets gender of the employee.
    /// </summary>
    public char Gender { get; set; }

    public override string ToString()
    {
        return $"{this.FullName} {this.Age} {this.Gender}";
    }
}
