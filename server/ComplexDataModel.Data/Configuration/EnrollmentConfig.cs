using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class EnrollmentConfig
{
  public static void ConfigureEnrollment(this ModelBuilder mb)
  {
        #region Composite Primary Keys

        mb.Entity<Enrollment>()
            .HasKey(x => new { x.CourseId, x.StudentId, x.Grade });

        #endregion
        #region One → Many

        mb.Entity<Enrollment>()
            .HasOne(x => x.Course)
            .WithMany(x => x.EnrolledStudents)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
  }
}