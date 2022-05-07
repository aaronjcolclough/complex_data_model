﻿// <auto-generated />
using System;
using ComplexDataModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComplexDataModel.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220507162737_string primary keys")]
    partial class stringprimarykeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentName");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Department", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.HasKey("Name");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Enrollment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.GivenName", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Value");

                    b.ToTable("GivenName", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Names.Surname", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Value");

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

                    b.Property<string>("FirstNameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastNameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MiddleNameId")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("CourseInstructor", (string)null);
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Instructor", b =>
                {
                    b.HasBaseType("ComplexDataModel.Data.Entities.Person");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("DepartmentName");

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
                        .HasForeignKey("DepartmentName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Enrollment", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
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
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComplexDataModel.Data.Entities.Names.Surname", "LastName")
                        .WithMany("LastNames")
                        .HasForeignKey("LastNameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ComplexDataModel.Data.Entities.Names.GivenName", "MiddleName")
                        .WithMany("MiddleNames")
                        .HasForeignKey("MiddleNameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FirstName");

                    b.Navigation("LastName");

                    b.Navigation("MiddleName");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplexDataModel.Data.Entities.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Instructor", b =>
                {
                    b.HasOne("ComplexDataModel.Data.Entities.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentName");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("ComplexDataModel.Data.Entities.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");
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
