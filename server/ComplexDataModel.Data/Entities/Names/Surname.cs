using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ComplexDataModel.Data.Entities.Names;

[Index(nameof(Value), IsUnique = true)]
public class Surname
{
    public int Id { get; set; }
    public string Value { get; set; }

    public IEnumerable<Person> LastNames { get; set; }
}