using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class InstructedCourseExtensions
{
    public static async Task<List<InstructedCourse>> GetInstructedCourses(this AppDbContext db) =>
        await db.InstructedCourses.ToListAsync();

    public static async Task<InstructedCourse> GetInstructedCourse(this AppDbContext db, int id) =>
        await db.InstructedCourses.FindAsync(id);

    public static async Task SaveInstructedCourse(this AppDbContext db, InstructedCourse ic)
    {
        if (ic.Validate())
        {
            if (ic.Id > 0)
            {
                await db.UpdateInstructedCourse(ic);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddInstructedCourse(ic);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddInstructedCourse(this AppDbContext db, InstructedCourse ic) =>
        await db.InstructedCourses.AddAsync(ic);

    public static async Task UpdateInstructedCourse(this AppDbContext db, InstructedCourse ic) =>
        await Task.Run(() => db.InstructedCourses.Update(ic));

    public static async Task RemoveInstructedCourse(this AppDbContext db, InstructedCourse ic) =>
        await Task.Run(() => db.InstructedCourses.Remove(ic));

    static void ClearNavProps(this InstructedCourse ic)
    {
        ic.Course = null;
        ic.Instructor = null;
        
        ic.EnrolledStudents = null;
    }

    static bool Validate(this InstructedCourse ic)
    {
        if (ic.InstructorId < 1)
            throw new AppException("Instructed Course must have an Instructor");

        if (string.IsNullOrEmpty(ic.CourseNumber) && string.IsNullOrEmpty(ic.DepartmentName))
            throw new AppException("Instructed Course must be associated to a Course");

        return true;
    }
}