using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;

public class Course
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string CourseNumber { get; set; }
    public string Title { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime StartDate { get; set; }

    [Range(0,5)]
    public int Credits { get; set; }

    public Department Department { get; set; }

    public IEnumerable<Enrollment> Enrollments { get; set; }
    public IEnumerable<Instructor> Instructors { get; set; }
}