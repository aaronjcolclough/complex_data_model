using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ComplexDataModel.Data.Entities;

[Index(nameof(CourseNumber), nameof(DepartmentId), IsUnique = true)]
public class Course
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string CourseNumber { get; set; }
    public string Title { get; set; }

    [Range(0,5)]
    public int Credits { get; set; }

    public Department Department { get; set; }

    public IEnumerable<InstructedCourse> Instructions { get; set; }
}