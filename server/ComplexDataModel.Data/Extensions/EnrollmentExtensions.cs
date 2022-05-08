using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Core;
using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions;

public static class EnrollmentExtensions
{
    public static async Task<List<Enrollment>> GetEnrollments(this AppDbContext db) =>
        await db.Enrollments.ToListAsync();

    public static async Task<Enrollment> GetEnrollment(this AppDbContext db, EnrollmentId id) =>
        await db.Enrollments.FindAsync(id.CourseId, id.StudentId);

    public static async Task SaveEnrollment(this AppDbContext db, Enrollment e)
    {
        if (e.Validate())
        {
            if (db.Enrollments.Any(x => x.CourseId == e.CourseId && x.StudentId == e.StudentId))
            {
                await db.UpdateEnrollment(e);
                await db.SaveChangesAsync();
            }
            else
            {
                await db.AddEnrollment(e);
                await db.SaveChangesAsync();
            }
        }
    }

    public static async Task AddEnrollment(this AppDbContext db, Enrollment e) =>
        await db.Enrollments.AddAsync(e);

    public static async Task UpdateEnrollment(this AppDbContext db, Enrollment e) =>
        await Task.Run(() => db.Enrollments.Update(e));

    public static async Task RemoveEnrollment(this AppDbContext db, Enrollment e) =>
        await Task.Run(() => db.Enrollments.Remove(e));

    static void ClearNavProps(this Enrollment e)
    {
        e.Course = null;
        e.Student = null;
    }

    static bool Validate(this Enrollment e)
    {
        if (e.CourseId < 1)
            throw new AppException("Enrollment must be associated to a Instructed Course");

        if (e.StudentId < 1)
            throw new AppException("Enrollment must be associated to a Student");

        return true;
    }
}