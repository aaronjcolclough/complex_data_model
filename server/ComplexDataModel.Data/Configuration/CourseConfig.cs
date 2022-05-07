using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class CourseConfig
{
  public static void ConfigureCourse(this ModelBuilder mb)
  {
        #region Composite Primary Keys

        mb.Entity<Course>()
            .HasKey(c => new { c.CourseNumber, c.DepartmentName });

        #endregion
        #region One → Many

        mb.Entity<Course>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.DepartmentName)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
  }
}