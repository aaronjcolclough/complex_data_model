using System.ComponentModel.DataAnnotations;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstNameId { get; set;}
    public string MiddleNameId { get; set;} = "NMN";
    public string LastNameId { get; set;}
    public string Type { get; set;}

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
    public string DepartmentName{ get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime HireDate { get; set; }

    public Office Office { get; set; }
    public Department Department { get; set; }

    public IEnumerable<Course> Courses { get; set; }
}