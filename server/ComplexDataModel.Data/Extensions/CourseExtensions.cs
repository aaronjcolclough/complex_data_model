using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class CourseExtensions
{
    public static async Task<List<Course>> GetCourses(this AppDbContext db) =>
        await db.Courses.ToListAsync();

    public static async Task<Course> GetCourse(this AppDbContext db, CourseId id) =>
        await db.Courses.FindAsync(id.CourseNumber, id.DepartmentName);

    public static async Task SaveCourse(this AppDbContext db, Course c)
    {
        if (c.Validate())
        {
            if (db.Courses.Any(x => x.CourseNumber == c.CourseNumber && x.DepartmentName == c.DepartmentName))
            {
                await db.UpdateCourse(c);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddCourse(c);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddCourse(this AppDbContext db, Course c) =>
        await db.Courses.AddAsync(c);

    public static async Task UpdateCourse(this AppDbContext db, Course c) =>
        await Task.Run(() => db.Courses.Update(c));

    public static async Task RemoveCourse(this AppDbContext db, Course c) =>
        await Task.Run(() => db.Courses.Remove(c));

    static void ClearNavProps(this Course c)
    {
        c.Department = null;
        c.Instructions = null;
    }

    static bool Validate(this Course c)
    {
        if (string.IsNullOrEmpty(c.Title))
            throw new AppException("Course must have a title");

        if (string.IsNullOrEmpty(c.CourseNumber))
            throw new AppException("Course must have a Course Number");

        if (string.IsNullOrEmpty(c.DepartmentName))
            throw new AppException("Course must have a Department Name");

        if (c.Credits < 5)
            throw new AppException("Course must have Credits assigned to it");

        return true;
    }
}