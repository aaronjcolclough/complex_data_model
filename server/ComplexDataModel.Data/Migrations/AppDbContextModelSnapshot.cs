// <auto-generated />
using System;
using ComplexDataModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComplexDataModel.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("CourseNumber", "DepartmentId")
                        .IsUnique()
                        .HasFilter("[CourseNumber] IS NOT NULL");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Enrollment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId", "Grade");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.InstructedCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructedCourse", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.GivenName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("GivenName", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.Surname", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("Surname", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Office", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Office", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FirstNameId")
                        .HasColumnType("int");

                    b.Property<int>("LastNameId")
                        .HasColumnType("int");

                    b.Property<int?>("MiddleNameId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FirstNameId");

                    b.HasIndex("LastNameId");

                    b.HasIndex("MiddleNameId");

                    b.ToTable("Person", (string)null);

                    b.HasDiscriminator<string>("Type").HasValue("Person");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Instructor", b =>
                {
                    b.HasBaseType("ComplexDataModel.Data.Entities.Person");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("instructor");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Student", b =>
                {
                    b.HasBaseType("ComplexDataModel.Data.Entities.Person");

                    b.Property<DateTime>("SchoolEnrollmentDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("student");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Course", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Enrollment", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.InstructedCourse", "Course")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.InstructedCourse", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Course", "Course")
                        .WithMany("Instructions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Office", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Instructor", "Instructor")
                        .WithOne("Office")
                        .HasForeignKey("ComplexDataModel.Data.Entities.Office", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Person", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Names.GivenName", "FirstName")
                        .WithMany("FirstNames")
                        .HasForeignKey("FirstNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Names.Surname", "LastName")
                        .WithMany("LastNames")
                        .HasForeignKey("LastNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Names.GivenName", "MiddleName")
                        .WithMany("MiddleNames")
                        .HasForeignKey("MiddleNameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FirstName");

                    b.Navigation("LastName");

                    b.Navigation("MiddleName");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Instructor", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Course", b =>
                {
                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.InstructedCourse", b =>
                {
                    b.Navigation("EnrolledStudents");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.GivenName", b =>
                {
                    b.Navigation("FirstNames");

                    b.Navigation("MiddleNames");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.Surname", b =>
                {
                    b.Navigation("LastNames");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Instructor", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
