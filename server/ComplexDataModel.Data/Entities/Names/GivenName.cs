using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ComplexDataModel.Data.Entities.Names;

public class GivenName : LookupEntity
{
    public IEnumerable<Person> FirstNames { get; set; }
    public IEnumerable<Person> MiddleNames { get; set; }
}