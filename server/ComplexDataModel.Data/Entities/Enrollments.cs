using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;

public enum Grade
{
    A, B, C, D, F
}

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }

    [DisplayFormat(NullDisplayText = "No Grade")]
    public Grade? Grade { get; set; }

    public Course Course { get; set; }
    public Student Student { get; set; }
}