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
                    InstructorId = instructors.Single(x => x.LastName.Value == "Harui").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "1050").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Zheng").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "4022").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Kapoor").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "4041").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Fakhouri").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "1045").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Fakhouri").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "3141").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Abercrombie").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "2021").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
                new InstructedCourse
                {
                    InstructorId = instructors.Single(x => x.LastName.Value == "Abercrombie").Id,
                    CourseId = courses.Single(x => x.CourseNumber == "2042").Id,
                    StartDate = DateTime.Parse("2007-09-01"),
                },
            };

            await db.InstructedCourses.AddRangeAsync(iCourses);
            await db.SaveChangesAsync();

            return iCourses;
        }
    }
}