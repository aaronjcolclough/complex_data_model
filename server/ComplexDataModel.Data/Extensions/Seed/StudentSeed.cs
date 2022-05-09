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
                        FirstNameId = givenNames.Single(x => x.Value == "Carson").Id,
                        LastNameId = surnames.Single(x => x.Value == "Alexander").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2010-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Meredith").Id,
                        LastNameId = surnames.Single(x => x.Value == "Alonso").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Arturo").Id,
                        LastNameId = surnames.Single(x => x.Value == "Anand").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2013-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Gytis").Id,
                        LastNameId = surnames.Single(x => x.Value == "Barzdukas").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Yan").Id,
                        LastNameId = surnames.Single(x => x.Value == "Li").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2012-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Peggy").Id,
                        LastNameId = surnames.Single(x => x.Value == "Justice").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2011-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Laura").Id,
                        LastNameId = surnames.Single(x => x.Value == "Norman").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2013-09-01"),
                    },
                new Student
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Nino").Id,
                        LastNameId = surnames.Single(x => x.Value == "Olivetto").Id,
                        SchoolEnrollmentDate = DateTime.Parse("2005-09-01")
                    }
           };

            await db.Students.AddRangeAsync(students);
            await db.SaveChangesAsync();

            return students;
       }

   }
}