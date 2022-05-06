namespace ComplexDataModel.Data.Entities.Names;

public class Surname
{
    public int Id { get; set; }
    public string Value { get; set; }

    public IEnumerable<Person> LastNames { get; set; }
}