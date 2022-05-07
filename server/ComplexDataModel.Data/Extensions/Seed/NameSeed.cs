using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class NameSeed
{
    public static async Task<(List<GivenName>, List<Surname>)> SeedNames(this AppDbContext db)
    {
        List<GivenName> givenNames;
        List<Surname> surnames;

        if (await db.GivenNames.AnyAsync())
        {
            Console.WriteLine("Retrieving GivenNames...");

            givenNames = await db.GivenNames.ToListAsync();
        }
        else
        {
            givenNames = new List<GivenName>
            {
                new GivenName { Value = "NMN"},
                new GivenName { Value = "Carson"},
                new GivenName { Value = "Meredith"},
                new GivenName { Value = "Arturo"},
                new GivenName { Value = "Gytis"},
                new GivenName { Value = "Yan"},
                new GivenName { Value = "Peggy"},
                new GivenName { Value = "Laura"},
                new GivenName { Value = "Nino"},
                new GivenName { Value = "Kim"},
                new GivenName { Value = "Fadi"},
                new GivenName { Value = "Roger"},
                new GivenName { Value = "Candace"}
            };

            await db.GivenNames.AddRangeAsync(givenNames);
            await db.SaveChangesAsync();
        }

        if (await db.Surnames.AnyAsync())
        {
            Console.WriteLine("Retrieving Surnames...");

            surnames = await db.Surnames.ToListAsync();
        }
        else
        {
            surnames = new List<Surname>
            {
                new Surname { Value = "Alexander"},
                new Surname { Value = "Alonso"},
                new Surname { Value = "Anand"},
                new Surname { Value = "Barzdukas"},
                new Surname { Value = "Li"},
                new Surname { Value = "Justice"},
                new Surname { Value = "Norman"},
                new Surname { Value = "Olivetto"},
                new Surname { Value = "Abercrombie"},
                new Surname { Value = "Fakhouri"},
                new Surname { Value = "Harui"},
                new Surname { Value = "Kapoor"},
                new Surname { Value = "Zheng"},
            };

            await db.Surnames.AddRangeAsync(surnames);
            await db.SaveChangesAsync();
        }

        return (givenNames, surnames);
    }
}