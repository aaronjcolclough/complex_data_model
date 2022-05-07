using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class InstructedCourseConfig
{
  public static void ConfigureInstructedCourse(this ModelBuilder mb)
  {
        #region Composite Foreign Keys

        mb.Entity<InstructedCourse>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Instructions)
            .HasForeignKey(x => new { x.CourseNumber, x.DepartmentName });

        #endregion
        #region One → Many

        mb.Entity<InstructedCourse>()
            .HasOne(x => x.Instructor)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.InstructorId);

        #endregion
  }
}