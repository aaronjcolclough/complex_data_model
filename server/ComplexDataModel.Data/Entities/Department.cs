using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexDataModel.Data.Entities;

public class Department
{
    public int Id { get; set; }
    public int DepartmentHeadId { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public decimal Budget { get; set; }

    public Instructor DepartmentHead { get; set; }

    public IEnumerable<Instructor> Instructors { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}