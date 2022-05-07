using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class DepartmentSeed
{
    public static async Task<List<Department>> SeedDepartments(this AppDbContext db, List<Instructor> instructors, List<Surname> surnames)
    {
        if (await db.Departments.AnyAsync())
        {
            Console.WriteLine("Retrieving Departments...");

            return await db.Departments.ToListAsync();
        }
        else
        {
            var departments = new List<Department>
            {
                new Department
                    {
                        // DepartmentHeadId = instructors.Single(x =>
                        //     x.LastNameId == surnames.Find()
                        //     ).Id,
                        // LastNameId = surnames.Single(x => x.Value == "Abercrombie").Id,
                        // HireDate = DateTime.Parse("2007-09-01")
                    },
            };

            await db.Departments.AddRangeAsync(departments);
            await db.SaveChangesAsync();

            return departments;
        }

    }
}