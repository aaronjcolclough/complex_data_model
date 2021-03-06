using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class DepartmentExtensions
{
    public static async Task<List<Department>> GetDepartments(this AppDbContext db) =>
        await db.Departments.ToListAsync();

    public static async Task<Department> GetDepartment(this AppDbContext db, int id) =>
        await db.Departments.FindAsync(id);

    public static async Task SaveDepartment(this AppDbContext db, Department d)
    {
        if (d.Validate())
        {
            if (d.Id > 0)
            {
                await db.UpdateDepartment(d);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddDepartment(d);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddDepartment(this AppDbContext db, Department d) =>
        await db.Departments.AddAsync(d);

    public static async Task UpdateDepartment(this AppDbContext db, Department d) =>
        await Task.Run(() => db.Departments.Update(d));

    public static async Task RemoveDepartment(this AppDbContext db, Department d) =>
        await Task.Run(() => db.Departments.Remove(d));

    static void ClearNavProps(this Department d)
    {
        d.Courses = null;
        d.Instructors = null;
    }

    static bool Validate(this Department d)
    {
        if (string.IsNullOrEmpty(d.Name))
            throw new AppException("Department must have a name");

        return true;
    }
}