using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class PersonExtensions
{
    public static async Task<List<T>> GetPeople<T>(this AppDbContext db) where T : Person =>
        await db.Set<T>().ToListAsync();

    public static async Task<T> GetPerson<T>(this AppDbContext db, int id) where T : Person =>
        await db.Set<T>().FindAsync(id);

    public static async Task SavePerson<T>(this AppDbContext db, T p) where T : Person
    {
        if (p.Validate<T>())
        {
            if (p.Id > 0)
            {
                await db.UpdatePerson<T>(p);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddPerson<T>(p);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddPerson<T>(this AppDbContext db, T p) where T : Person =>
        await db.People.AddAsync(p);

    public static async Task UpdatePerson<T>(this AppDbContext db, T p) where T : Person =>
        await Task.Run(() => db.Set<T>().Update(p));

    public static async Task RemovePerson(this AppDbContext db, Person p) =>
        await Task.Run(() => db.People.Remove(p));

    static void ClearNavProps<T>(this T p) where T : Person
    {
        p.FirstNameNav = null;
        p.MiddleNameNav = null;
        p.LastNameNav = null;
        
        switch (p)
        {
            case Instructor i:
                i.Department = null;
                i.Office = null;
                i.Courses = null;
                break;
            case Student s:
                s.Enrollments = null;
                break;
            default:
                break;
        }
    }

    static bool Validate<T>(this T p) where T : Person
    {
        if (string.IsNullOrEmpty(p.FirstName))
            throw new AppException("Person must have a first name");

        if (string.IsNullOrEmpty(p.LastName))
            throw new AppException("Person must have a last name");

        switch (p)
        {
            case Instructor i:
                return i.ValidateInstructor();
        }

        return true;
    }

    static bool ValidateInstructor(this Instructor i)
    {
        if (string.IsNullOrEmpty(i.DepartmentName))
            throw new AppException("Instructor must have a Department");

        return true;
    }
}