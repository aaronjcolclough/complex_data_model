using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class PersonConfig
{
  public static void ConfigurePerson(this ModelBuilder mb)
  {
        #region One → Many

        mb.Entity<Person>()
            .HasOne(x => x.FirstNameNav)
            .WithMany(x => x.FirstNames)
            .HasForeignKey(x => x.FirstName)
            .OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Person>()
            .HasOne(x => x.MiddleNameNav)
            .WithMany(x => x.MiddleNames)
            .HasForeignKey(x => x.MiddleName)
            .OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Person>()
            .HasOne(x => x.LastNameNav)
            .WithMany(x => x.LastNames)
            .HasForeignKey(x => x.LastName)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
        #region Discriminators

        mb.Entity<Person>()
            .HasDiscriminator(person => person.Type)
            .HasValue<Student>("student")
            .HasValue<Instructor>("instructor");

        #endregion

  }
}