using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class CourseExtensions
{
    public static async Task<List<Course>> GetAllCourses(this AppDbContext db) =>
        await db.Courses.ToListAsync();

    public static async Task<List<Course>> GetDepartmentCourses(this AppDbContext db, int id) =>
        await db.Courses
            .Where(x => x.DepartmentId == id)
            .ToListAsync();

    public static async Task<Course> GetCourse(this AppDbContext db, int id) =>
        await db.Courses.FindAsync(id);

    public static async Task SaveCourse(this AppDbContext db, Course c)
    {
        if (c.Validate())
        {
            if (c.Id > 0)
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

        if (c.DepartmentId > 0)
            throw new AppException("Course must have a Department Name");

        return true;
    }
}