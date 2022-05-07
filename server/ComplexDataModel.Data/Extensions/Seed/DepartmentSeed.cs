using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class DepartmentSeed
{
    public static async Task<List<Department>> SeedDepartments(this AppDbContext db)
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
                new Department { Name = "English",     Budget = 350000 },
                new Department { Name = "Mathematics", Budget = 100000 },
                new Department { Name = "Engineering", Budget = 350000 },
                new Department { Name = "Economics",   Budget = 100000 }
            };

            await db.Departments.AddRangeAsync(departments);
            await db.SaveChangesAsync();

            return departments;
        }

    }
}