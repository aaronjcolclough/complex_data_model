namespace ComplexDataModel.Data.Entities.Names;

public class GivenName
{
    public int Id { get; set; }
    public string Value { get; set; }

    public IEnumerable<Person> FirstNames { get; set; }
    public IEnumerable<Person> MiddleNames { get; set; }
}