using Microsoft.EntityFrameworkCore;

using ComplexDataModel.Data.Configuration;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;

namespace ComplexDataModel.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<GivenName> GivenNames { get; set; }
    public DbSet<InstructedCourse> InstructedCourses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Surname> Surnames { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ConfigureCourse();
        mb.ConfigureEnrollment();
        mb.ConfigureInstructedCourse();
        mb.ConfigureInstructor();
        mb.ConfigurePerson();

        mb.Model
            .GetEntityTypes()
            .Where(x => x.BaseType == null)
            .ToList()
            .ForEach(x =>
            {
                mb.Entity(x.Name)
                    .ToTable(x.Name.Split('.').Last());
            });
    }
}