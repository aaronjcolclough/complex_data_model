using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;

public class InstructedCourse
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public string CourseNumber { get; set; }
    public string DepartmentName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime StartDate { get; set; }

    public Course Course { get; set; }
    public Instructor Instructor { get; set; }

    public IEnumerable<Enrollment> EnrolledStudents { get; set; }
}