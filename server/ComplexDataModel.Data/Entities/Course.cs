using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;

public class Course
{
    public string CourseNumber { get; set; }
    public string DepartmentName { get; set; }
    public string Title { get; set; }

    [Range(0,5)]
    public int Credits { get; set; }

    public Department Department { get; set; }

    public IEnumerable<InstructedCourse> Instructions { get; set; }
}