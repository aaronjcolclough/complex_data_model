using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class InstructorConfig
{
  public static void ConfigureInstructor(this ModelBuilder mb)
  {
        #region One → Many

        mb.Entity<Instructor>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Instructors)
            .HasForeignKey(x => x.DepartmentName)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
  }
}