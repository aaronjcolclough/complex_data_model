using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class StudentSeed
{
    public static async Task<List<Student>> SeedStudents(this AppDbContext db, (List<GivenName>, List<Surname>) names)
    {
        var (givenNames, surnames) = names;

        if (await db.Students.AnyAsync())
        {
            Console.WriteLine("Retrieving Students...");

            return await db.Students.ToListAsync();
        }
        else
        {
            var students = new List<Student>
            {
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Carson").Value,
                        LastName = surnames.Single(x => x.Value == "Alexander").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2010-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Meredith").Value,
                        LastName = surnames.Single(x => x.Value == "Alonso").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Arturo").Value,
                        LastName = surnames.Single(x => x.Value == "Anand").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2013-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Gytis").Value,
                        LastName = surnames.Single(x => x.Value == "Barzdukas").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Yan").Value,
                        LastName = surnames.Single(x => x.Value == "Li").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Peggy").Value,
                        LastName = surnames.Single(x => x.Value == "Justice").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2011-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Laura").Value,
                        LastName = surnames.Single(x => x.Value == "Norman").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2013-09-01"),
                    },
                new Student
                    {
                        FirstName = givenNames.Single(x => x.Value == "Nino").Value,
                        LastName = surnames.Single(x => x.Value == "Olivetto").Value,
                        SchoolEnrollmentDate = DateTime.Parse("2005-09-01")
                    }
           };

            await db.Students.AddRangeAsync(students);
            await db.SaveChangesAsync();

            return students;
       }

   }
}