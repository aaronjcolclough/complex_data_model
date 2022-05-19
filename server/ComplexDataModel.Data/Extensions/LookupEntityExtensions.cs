using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComplexDataModel.Data.Extensions;

public static class LookupEntityExtensions
{
    public static async Task<List<T>> GetMany<T>(this AppDbContext db) where T : LookupEntity =>
        await db.Set<T>().ToListAsync();

    public static async Task<T> Get<T>(this AppDbContext db, int id) where T : LookupEntity =>
        await db.Set<T>().FindAsync(id);

    public static async Task Save<T>(this T le, AppDbContext db) where T : LookupEntity
    {
        if (le.Validate())
        {
            if (le.Id > 0)
                await le.Update(db);
            else
                await le.Add(db);
        }
    }

    static async Task Add<T>(this T le, AppDbContext db) where T : LookupEntity
    {
        await db.Set<T>().AddAsync(le);
        await db.SaveChangesAsync();

    }

    static async Task Update<T>(this T le, AppDbContext db) where T : LookupEntity
    {
        db.Set<T>().Update(le);
        await db.SaveChangesAsync();
    }

    public static async Task Remove<T>(this T le, AppDbContext db) where T : LookupEntity
    {
        db.Set<T>().Remove(le);
        await db.SaveChangesAsync();
    }

    static void ClearNavProps<T>(this T le)
    {
        // le.FirstNames = null;
        // le.MiddleNames = null;
    }

    static bool Validate(this LookupEntity le)
    {
        if (string.IsNullOrEmpty(le.Value))
            throw new AppException("Entity must have a value");

        return true;
    }
}