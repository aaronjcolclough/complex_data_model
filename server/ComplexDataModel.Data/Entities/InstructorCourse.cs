namespace ComplexDataModel.Data.Entities;

public class InstructorCourse
{
    public int CourseId { get; set; }
    public int InstructorId { get; set; }

    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
}