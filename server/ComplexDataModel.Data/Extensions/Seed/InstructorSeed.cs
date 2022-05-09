using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class InstructorSeed
{
    public static async Task<List<Instructor>> SeedInstructors(this AppDbContext db, (List<GivenName>, List<Surname>) names, List<Department> departments)
    {
        var (givenNames, surnames) = names;

        if (await db.Instructors.AnyAsync())
        {
            Console.WriteLine("Retrieving Instructors...");

            return await db.Instructors.ToListAsync();
        }
        else
        {
            var instructors = new List<Instructor>
            {
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Kim").Id,
                        LastNameId = surnames.Single(x => x.Value == "Abercrombie").Id,
                        HireDate = DateTime.Parse("2007-09-01"),
                        DepartmentId = departments.Single(x => x.Name == "English").Id
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Fadi").Id,
                        LastNameId = surnames.Single(x => x.Value == "Fakhouri").Id,
                        HireDate = DateTime.Parse("2007-09-01"),
                        DepartmentId = departments.Single(x => x.Name == "Mathematics").Id
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Roger").Id,
                        LastNameId = surnames.Single(x => x.Value == "Harui").Id,
                        HireDate = DateTime.Parse("2007-09-01"),
                        DepartmentId = departments.Single(x => x.Name == "Engineering").Id
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Candace").Id,
                        LastNameId = surnames.Single(x => x.Value == "Kapoor").Id,
                        HireDate = DateTime.Parse("2007-09-01"),
                        DepartmentId = departments.Single(x => x.Name == "Economics").Id
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Roger").Id,
                        LastNameId = surnames.Single(x => x.Value == "Zheng").Id,
                        HireDate = DateTime.Parse("2012-09-01"),
                        DepartmentId = departments.Single(x => x.Name == "Economics").Id
                    },
            };

            await db.Instructors.AddRangeAsync(instructors);
            await db.SaveChangesAsync();

            return instructors;
        }

    }
}