using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class InstructorSeed
{
    public static async Task<List<Instructor>> SeedInstructors(this AppDbContext db, (List<GivenName>, List<Surname>) names)
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
                        FirstNameId = givenNames.Single(x => x.Value == "Kim").Value,
                        LastNameId = surnames.Single(x => x.Value == "Abercrombie").Value,
                        HireDate = DateTime.Parse("2007-09-01")
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Fadi").Value,
                        LastNameId = surnames.Single(x => x.Value == "Fakhouri").Value,
                        HireDate = DateTime.Parse("2007-09-01")
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Roger").Value,
                        LastNameId = surnames.Single(x => x.Value == "Harui").Value,
                        HireDate = DateTime.Parse("2007-09-01")
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Candace").Value,
                        LastNameId = surnames.Single(x => x.Value == "Kapoor").Value,
                        HireDate = DateTime.Parse("2007-09-01")
                    },
                new Instructor
                    {
                        FirstNameId = givenNames.Single(x => x.Value == "Roger").Value,
                        LastNameId = surnames.Single(x => x.Value == "Zheng").Value,
                        HireDate = DateTime.Parse("2012-09-01")
                    },
            };

            await db.Instructors.AddRangeAsync(instructors);
            await db.SaveChangesAsync();

            return instructors;
        }

    }
}