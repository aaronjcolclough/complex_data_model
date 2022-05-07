using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplexDataModel.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "GivenName",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GivenName", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Surname",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surname", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => new { x.CourseNumber, x.DepartmentName });
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolEnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_GivenName_FirstName",
                        column: x => x.FirstName,
                        principalTable: "GivenName",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_GivenName_MiddleName",
                        column: x => x.MiddleName,
                        principalTable: "GivenName",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Surname_LastName",
                        column: x => x.LastName,
                        principalTable: "Surname",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructedCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructedCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructedCourse_Course_CourseNumber_DepartmentName",
                        columns: x => new { x.CourseNumber, x.DepartmentName },
                        principalTable: "Course",
                        principalColumns: new[] { "CourseNumber", "DepartmentName" });
                    table.ForeignKey(
                        name: "FK_InstructedCourse_Person_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Office_Person_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.CourseId, x.StudentId, x.Grade });
                    table.ForeignKey(
                        name: "FK_Enrollment_InstructedCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "InstructedCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Person_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentName",
                table: "Course",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructedCourse_CourseNumber_DepartmentName",
                table: "InstructedCourse",
                columns: new[] { "CourseNumber", "DepartmentName" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructedCourse_InstructorId",
                table: "InstructedCourse",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentName",
                table: "Person",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FirstName",
                table: "Person",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_LastName",
                table: "Person",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MiddleName",
                table: "Person",
                column: "MiddleName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "InstructedCourse");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "GivenName");

            migrationBuilder.DropTable(
                name: "Surname");
        }
    }
}
