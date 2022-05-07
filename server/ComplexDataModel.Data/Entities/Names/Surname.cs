using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities.Names;

public class Surname
{
    [Key]
    public string Value { get; set; }

    public IEnumerable<Person> LastNames { get; set; }
}