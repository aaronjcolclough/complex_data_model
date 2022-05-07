using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplexDataModel.Data.Migrations
{
    public partial class stringprimarykeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Person_DepartmentHeadId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_GivenName_FirstNameId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_GivenName_MiddleNameId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Surname_LastNameId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surname",
                table: "Surname");

            migrationBuilder.DropIndex(
                name: "IX_Person_DepartmentId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentHeadId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Surname");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsHead",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GivenName");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentHeadId",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Person",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Surname",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleNameId",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastNameId",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstNameId",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "GivenName",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surname",
                table: "Surname",
                column: "Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName",
                column: "Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentName",
                table: "Person",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentName",
                table: "Course",
                column: "DepartmentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentName",
                table: "Course",
                column: "DepartmentName",
                principalTable: "Department",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentName",
                table: "Person",
                column: "DepartmentName",
                principalTable: "Department",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_GivenName_FirstNameId",
                table: "Person",
                column: "FirstNameId",
                principalTable: "GivenName",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_GivenName_MiddleNameId",
                table: "Person",
                column: "MiddleNameId",
                principalTable: "GivenName",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Surname_LastNameId",
                table: "Person",
                column: "LastNameId",
                principalTable: "Surname",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentName",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentName",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_GivenName_FirstNameId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_GivenName_MiddleNameId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Surname_LastNameId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surname",
                table: "Surname");

            migrationBuilder.DropIndex(
                name: "IX_Person_DepartmentName",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentName",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Person",
                newName: "Discriminator");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Surname",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Surname",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MiddleNameId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastNameId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstNameId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHead",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "GivenName",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GivenName",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentHeadId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surname",
                table: "Surname",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GivenName",
                table: "GivenName",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentId",
                table: "Person",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentHeadId",
                table: "Department",
                column: "DepartmentHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentId",
                table: "Course",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Person_DepartmentHeadId",
                table: "Department",
                column: "DepartmentHeadId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_GivenName_FirstNameId",
                table: "Person",
                column: "FirstNameId",
                principalTable: "GivenName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_GivenName_MiddleNameId",
                table: "Person",
                column: "MiddleNameId",
                principalTable: "GivenName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Surname_LastNameId",
                table: "Person",
                column: "LastNameId",
                principalTable: "Surname",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
