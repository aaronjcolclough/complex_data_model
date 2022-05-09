using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data.Extensions;

public static class NameExtensions
{
    #region GivenName

    public static async Task<GivenName> GetGivenName(this AppDbContext db, int id) =>
        await db.GivenNames.FindAsync(id);

    public static async Task SaveGivenName(this AppDbContext db, GivenName gn)
    {
        if (gn.Validate())
        {
            if (gn.Id > 0)
            {
                await db.UpdateGivenName(gn);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddGivenName(gn);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddGivenName(this AppDbContext db, GivenName gn) =>
        await db.GivenNames.AddAsync(gn);

    public static async Task UpdateGivenName(this AppDbContext db, GivenName gn) =>
        await Task.Run(() => db.GivenNames.Update(gn));

    public static async Task RemoveGivenName(this AppDbContext db, GivenName gn) =>
        await Task.Run(() => db.GivenNames.Remove(gn));

    static void ClearNavProps(this GivenName gn)
    {
        gn.FirstNames = null;
        gn.MiddleNames = null;
    }

    static bool Validate(this GivenName gn)
    {
        if (string.IsNullOrEmpty(gn.Value))
            throw new AppException("Given Name must have a value");

        return true;
    }

    #endregion
    #region Surname

    public static async Task<Surname> GetSurname(this AppDbContext db, int id) =>
        await db.Surnames.FindAsync(id);

    public static async Task SaveSurname(this AppDbContext db, Surname sn)
    {
        if (sn.Validate())
        {
            if (sn.Id > 0)
            {
                await db.UpdateSurname(sn);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddSurname(sn);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddSurname(this AppDbContext db, Surname sn) =>
        await db.Surnames.AddAsync(sn);

    public static async Task UpdateSurname(this AppDbContext db, Surname sn) =>
        await Task.Run(() => db.Surnames.Update(sn));

    public static async Task RemoveSurname(this AppDbContext db, Surname sn) =>
        await Task.Run(() => db.Surnames.Remove(sn));

    static void ClearNavProps(this Surname sn)
    {
        sn.LastNames = null;
    }

    static bool Validate(this Surname sn)
    {
        if (string.IsNullOrEmpty(sn.Value))
            throw new AppException("Surname must have a value");

        return true;
    }

    #endregion
}