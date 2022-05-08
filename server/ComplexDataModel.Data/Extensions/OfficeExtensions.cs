using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class OfficeExtensions
{
    public static async Task<List<Office>> GetOffices(this AppDbContext db) =>
        await db.Offices.ToListAsync();

    public static async Task<Office> GetOffice(this AppDbContext db, int id) =>
        await db.Offices.FindAsync(id);

    public static async Task SaveOffice(this AppDbContext db, Office o)
    {
        if (o.Validate())
        {
            if (db.Offices.Any(x => x.InstructorId == o.InstructorId))
            {
                await db.UpdateOffice(o);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddOffice(o);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddOffice(this AppDbContext db, Office o) =>
        await db.Offices.AddAsync(o);

    public static async Task UpdateOffice(this AppDbContext db, Office o) =>
        await Task.Run(() => db.Offices.Update(o));

    public static async Task RemoveOffice(this AppDbContext db, Office o) =>
        await Task.Run(() => db.Offices.Remove(o));

    static void ClearNavProps(this Office o)
    {
        o.Instructor = null;
    }

    static bool Validate(this Office o)
    {
        if (string.IsNullOrEmpty(o.Room))
            throw new AppException("Office must have a room number");

        if (string.IsNullOrEmpty(o.Building))
            throw new AppException("Office must have a building associated to it");

        if (o.InstructorId > 0)
            throw new AppException("Office must have an Instructor assigned to it");

        return true;
    }
}