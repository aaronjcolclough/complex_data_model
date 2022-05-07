using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;
using ComplexDataModel.Data.Extensions.Seed;

namespace ComplexDataModel.Data.Extensions;

public static class DbInitializer
{
    public static async Task Initialize(this AppDbContext db)
    {
        Console.WriteLine("Initializing database");
        await db.Database.MigrateAsync();
        Console.WriteLine("Database initialized");

        var (givenNames, surnames) = await db.SeedNames();
        var students = await db.SeedStudents((givenNames, surnames));
        var instructors = await db.SeedInstructors((givenNames, surnames));
        // var departments = await db.SeedDepartments(instructors, surnames);
    }
}

//             var departments = new Department[]
//             {
//                 new Department { Name = "English",     Budget = 350000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
//                 new Department { Name = "Mathematics", Budget = 100000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
//                 new Department { Name = "Engineering", Budget = 350000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
//                 new Department { Name = "Economics",   Budget = 100000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
//             };

//             foreach (Department d in departments)
//             {
//                 context.Departments.Add(d);
//             }
//             context.SaveChanges();

//             var courses = new Course[]
//             {
//                 new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
//                 },
//                 new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
//                 },
//                 new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
//                 },
//                 new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
//                 },
//                 new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
//                 },
//                 new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
//                 },
//                 new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
//                 },
//             };

//             foreach (Course c in courses)
//             {
//                 context.Courses.Add(c);
//             }
//             context.SaveChanges();

//             var officeAssignments = new OfficeAssignment[]
//             {
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
//                     Location = "Smith 17" },
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
//                     Location = "Gowan 27" },
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
//                     Location = "Thompson 304" },
//             };

//             foreach (OfficeAssignment o in officeAssignments)
//             {
//                 context.OfficeAssignments.Add(o);
//             }
//             context.SaveChanges();

//             var courseInstructors = new CourseAssignment[]
//             {
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Harui").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Harui").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
//                     },
//             };

//             foreach (CourseAssignment ci in courseInstructors)
//             {
//                 context.CourseAssignments.Add(ci);
//             }
//             context.SaveChanges();

//             var enrollments = new Enrollment[]
//             {
//                 new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     Grade = Grade.A
//                 },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
//                     Grade = Grade.C
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Anand").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Anand").ID,
//                     CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
//                     Grade = Grade.B
//                     },
//                 new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Li").ID,
//                     CourseID = courses.Single(c => c.Title == "Composition").CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Justice").ID,
//                     CourseID = courses.Single(c => c.Title == "Literature").CourseID,
//                     Grade = Grade.B
//                     }
//             };

//             foreach (Enrollment e in enrollments)
//             {
//                 var enrollmentInDataBase = context.Enrollments.Where(
//                     s =>
//                             s.Student.ID == e.StudentID &&
//                             s.Course.CourseID == e.CourseID).SingleOrDefault();
//                 if (enrollmentInDataBase == null)
//                 {
//                     context.Enrollments.Add(e);
//                 }
//             }
//             context.SaveChanges();
//         }
//     }
// }