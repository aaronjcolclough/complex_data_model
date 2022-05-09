using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Configuration;

public static class PersonConfig
{
  public static void ConfigurePerson(this ModelBuilder mb)
  {
        #region One → Many

        mb.Entity<Person>()
            .HasOne(x => x.FirstName)
            .WithMany(x => x.FirstNames)
            .HasForeignKey(x => x.FirstNameId)
            .OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Person>()
            .HasOne(x => x.MiddleName)
            .WithMany(x => x.MiddleNames)
            .HasForeignKey(x => x.MiddleNameId)
            .OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Person>()
            .HasOne(x => x.LastName)
            .WithMany(x => x.LastNames)
            .HasForeignKey(x => x.LastNameId)
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