using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Extensions.Seed;

namespace ComplexDataModel.Data.Extensions;

public static class DbInitializer
{
    public static async Task Initialize(this AppDbContext db)
    {
        Console.WriteLine("Initializing database");
        await db.Database.MigrateAsync();
        Console.WriteLine("Database initialized");

        await db.SeedDepartments();
        var courses = await db.SeedCourses();
        var (givenNames, surnames) = await db.SeedNames();
        var students = await db.SeedStudents((givenNames, surnames));
        var instructors = await db.SeedInstructors((givenNames, surnames));
        await db.SeedOffices(instructors);
        var instructedCourses = await db.SeedInstructedCourses(instructors, courses);
        await db.SeedEnrollments(instructedCourses, students);
    }
}