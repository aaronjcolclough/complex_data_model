using Microsoft.EntityFrameworkCore;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Composite Primary Keys

        modelBuilder
            .Entity<Course>()
            .HasKey(c => new { c.CourseNumber, c.DepartmentName });

        modelBuilder
            .Entity<Enrollment>()
            .HasKey(x => new { x.CourseId, x.StudentId, x.Grade });

        #endregion
        #region Composite Foreign Keys

        modelBuilder
            .Entity<InstructedCourse>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Instructions)
            .HasForeignKey(x => new { x.CourseNumber, x.DepartmentName });

        #endregion
        #region One → Many

        modelBuilder
            .Entity<Course>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.DepartmentName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Enrollment>()
            .HasOne(x => x.Course)
            .WithMany(x => x.EnrolledStudents)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<InstructedCourse>()
            .HasOne(x => x.Instructor)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.InstructorId);

        modelBuilder
            .Entity<Instructor>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Instructors)
            .HasForeignKey(x => x.DepartmentName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.FirstNameNav)
            .WithMany(x => x.FirstNames)
            .HasForeignKey(x => x.FirstName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.MiddleNameNav)
            .WithMany(x => x.MiddleNames)
            .HasForeignKey(x => x.MiddleName)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.LastNameNav)
            .WithMany(x => x.LastNames)
            .HasForeignKey(x => x.LastName)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
        #region Discriminators

        modelBuilder
            .Entity<Person>()
            .HasDiscriminator(person => person.Type)
            .HasValue<Student>("student")
            .HasValue<Instructor>("instructor");

        #endregion

        modelBuilder
            .Model
            .GetEntityTypes()
            .Where(x => x.BaseType == null)
            .ToList()
            .ForEach(x =>
            {
                modelBuilder
                    .Entity(x.Name)
                    .ToTable(x.Name.Split('.').Last());
            });
    }
}