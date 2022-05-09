using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;

namespace ComplexDataModel.Data.Extensions.Seed;

public static class EnrollmentSeed
{
    public static async Task<List<Enrollment>> SeedEnrollments(this AppDbContext db, List<InstructedCourse> courses, List<Student> students)
    {
        if (await db.Enrollments.AnyAsync())
        {
            Console.WriteLine("Retrieving Enrollments...");

            return await db.Enrollments.ToListAsync();
        }
        else
        {
            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alexander").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "1050").Id,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alexander").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "4022").Id,
                    Grade = Grade.C
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alexander").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "4041").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alonso").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "1045").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alonso").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "3141").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Alonso").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "2021").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Anand").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "1050").Id,
                    Grade = Grade.I
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Anand").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "4022").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Barzdukas").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "1050").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Li").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "2021").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single(x => x.LastName.Value == "Justice").Id,
                    CourseId = courses.Single(x => x.Course.CourseNumber == "2042").Id,
                    Grade = Grade.B
                }
            };

            await db.Enrollments.AddRangeAsync(enrollments);
            await db.SaveChangesAsync();

            return enrollments;
        }

    }
}