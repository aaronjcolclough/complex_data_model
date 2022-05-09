using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class CourseSeed
{
    public static async Task<List<Course>> SeedCourses(this AppDbContext db, List<Department> departments)
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
                    DepartmentId = departments.Single(x => x.Name == "Engineering").Id
                },
                new Course
                {
                    CourseNumber = "4022",
                    Title = "Microeconomics",
                    Credits = 3,
                    DepartmentId = departments.Single(x => x.Name == "Economics").Id
                },
                new Course
                {
                    CourseNumber = "4041",
                    Title = "Macroeconomics",
                    Credits = 3,
                    DepartmentId = departments.Single(x => x.Name == "Economics").Id
                },
                new Course
                {
                    CourseNumber = "1045",
                    Title = "Calculus",
                    Credits = 4,
                    DepartmentId = departments.Single(x => x.Name == "Mathematics").Id
                },
                new Course
                {
                    CourseNumber = "3141",
                    Title = "Trigonometry",
                    Credits = 4,
                    DepartmentId = departments.Single(x => x.Name == "Mathematics").Id
                },
                new Course
                {
                    CourseNumber = "2021",
                    Title = "Composition",
                    Credits = 3,
                    DepartmentId = departments.Single(x => x.Name == "English").Id
                },
                new Course
                {
                    CourseNumber = "2042",
                    Title = "Literature",
                    Credits = 4,
                    DepartmentId = departments.Single(x => x.Name == "English").Id
                },
            };

            await db.Courses.AddRangeAsync(courses);
            await db.SaveChangesAsync();

            return courses;
        }

    }
}