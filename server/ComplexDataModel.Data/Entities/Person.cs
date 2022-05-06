using System.ComponentModel.DataAnnotations;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Entities;

public class Person
{
    public int Id { get; set; }
    public int FirstNameId { get; set;}
    public int MiddleNameId { get; set;}
    public int LastNameId { get; set;}

    public GivenName FirstName { get; set; }
    public GivenName MiddleName { get; set; }
    public Surname LastName { get; set; }
}

public class Student : Person
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime SchoolEnrollmentDate { get; set; }

    public IEnumerable<Enrollment> Enrollments { get; set; }
}

public class Instructor : Person
{
    public int DepartmentId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime HireDate { get; set; }
    public bool IsHead { get; set; }

    public Office Office { get; set; }
    public Department Department { get; set; }

    public IEnumerable<Course> Courses { get; set; }
}