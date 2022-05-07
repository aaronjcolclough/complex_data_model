using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class InstructedCourseSeed
{
    public static async Task<List<InstructedCourse>> SeedInstructedCourses(this AppDbContext db, List<Instructor> instructors, List<Course> courses)
    {
        if (await db.InstructedCourses.AnyAsync())
        {
            Console.WriteLine("Retrieving InstructedCourses...");

            return await db.InstructedCourses.ToListAsync();
        }
        else
        {
            var iCourses = new List<InstructedCourse>
            {
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Harui").Id,
                    CourseNumber = "1050",
                    DepartmentName = "Engineering",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Zheng").Id,
                    CourseNumber = "4022",
                    DepartmentName = "Economics",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Kapoor").Id,
                    CourseNumber = "4041",
                    DepartmentName = "Economics",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Fakhouri").Id,
                    CourseNumber = "1045",
                    DepartmentName = "Mathematics",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Fakhouri").Id,
                    CourseNumber = "3141",
                    DepartmentName = "Mathematics",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Abercrombie").Id,
                    CourseNumber = "2021",
                    DepartmentName = "English",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName == "Abercrombie").Id,
                    CourseNumber = "2042",
                    DepartmentName = "English",
                    StartDate = DateTime.Parse("2007-09-01"),
                },
            };

            await db.InstructedCourses.AddRangeAsync(iCourses);
            await db.SaveChangesAsync();

            return iCourses;
        }
    }
}