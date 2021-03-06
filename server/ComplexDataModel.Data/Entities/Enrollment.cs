using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;

public enum Grade
{
    A, B, C, D, F, I
}

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }

    public Grade Grade { get; set; }

    public InstructedCourse Course { get; set; }
    public Student Student { get; set; }
}