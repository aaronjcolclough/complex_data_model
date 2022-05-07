using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class CourseSeed
{
    public static async Task<List<Course>> SeedCourses(this AppDbContext db)
    {
        if (await db.Courses.AnyAsync())
        {
            Console.WriteLine("Retrieving Courses...");

            return await db.Courses.ToListAsync();
        }
        else
        {
            var courses = new List<Course>
            {
                new Course
                {
                    CourseNumber = "1050",
                    Title = "Chemistry",
                    Credits = 3,
                    DepartmentName = "Engineering"
                },
                new Course
                {
                    CourseNumber = "4022",
                    Title = "Microeconomics",
                    Credits = 3,
                    DepartmentName = "Economics"
                },
                new Course
                {
                    CourseNumber = "4041",
                    Title = "Macroeconomics",
                    Credits = 3,
                    DepartmentName = "Economics"
                },
                new Course
                {
                    CourseNumber = "1045",
                    Title = "Calculus",
                    Credits = 4,
                    DepartmentName = "Mathematics"
                },
                new Course
                {
                    CourseNumber = "3141",
                    Title = "Trigonometry",
                    Credits = 4,
                    DepartmentName = "Mathematics"
                },
                new Course
                {
                    CourseNumber = "2021",
                    Title = "Composition",
                    Credits = 3,
                    DepartmentName = "English"
                },
                new Course
                {
                    CourseNumber = "2042",
                    Title = "Literature",
                    Credits = 4,
                    DepartmentName = "English"
                },
            };

            await db.Courses.AddRangeAsync(courses);
            await db.SaveChangesAsync();

            return courses;
        }

    }
}