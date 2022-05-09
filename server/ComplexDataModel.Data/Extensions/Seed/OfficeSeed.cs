using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class OfficeSeed
{
    public static async Task<List<Office>> SeedOffices(this AppDbContext db, List<Instructor> instructors)
    {
        if (await db.Offices.AnyAsync())
        {
            Console.WriteLine("Retrieving Offices...");

            return await db.Offices.ToListAsync();
        }
        else
        {
            var offices = new List<Office>
            {
                new Office
                {
                    InstructorId = instructors.Single( i => i.LastName.Value == "Fakhouri").Id,
                    Room = "17",
                    Building = "Smith"
                },
                new Office
                {
                    InstructorId = instructors.Single( i => i.LastName.Value == "Harui").Id,
                    Room = "27",
                    Building = "Gowan"
                },
                new Office
                {
                    InstructorId = instructors.Single( i => i.LastName.Value == "Kapoor").Id,
                    Room = "304",
                    Building = "Thompson"
                },
            };

            await db.Offices.AddRangeAsync(offices);
            await db.SaveChangesAsync();

            return offices;
        }

    }
}