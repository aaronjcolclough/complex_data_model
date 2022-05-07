using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities.Names;

public class GivenName
{
    [Key]
    public string Value { get; set; }

    public IEnumerable<Person> FirstNames { get; set; }
    public IEnumerable<Person> MiddleNames { get; set; }
}