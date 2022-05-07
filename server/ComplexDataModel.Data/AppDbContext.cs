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
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Surname> Surnames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Composite Primary Keys

        modelBuilder
            .Entity<Enrollment>()
            .HasKey(x => new { x.CourseId, x.StudentId });

        #endregion
        #region One → Many

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.FirstName)
            .WithMany(x => x.FirstNames)
            .HasForeignKey(x => x.FirstNameId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.MiddleName)
            .WithMany(x => x.MiddleNames)
            .HasForeignKey(x => x.MiddleNameId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Person>()
            .HasOne(x => x.LastName)
            .WithMany(x => x.LastNames)
            .HasForeignKey(x => x.LastNameId)
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