using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppFundamentals.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostedServiceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostedServiceLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 50, nullable: false),
                    Enrollment = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IdSubject = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IdSubject);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 12, nullable: false),
                    Schedule = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IdTeacher);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsStudents",
                columns: table => new
                {
                    IdSubject = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 12, nullable: false),
                    Note = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsStudents", x => new { x.IdSubject, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_SubjectsStudents_Students_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Students",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsStudents_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsTeachers",
                columns: table => new
                {
                    IdSubject = table.Column<int>(nullable: false),
                    IdTeacher = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsTeachers", x => new { x.IdSubject, x.IdTeacher });
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Teachers_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IdTeacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsStudents_IdStudent",
                table: "SubjectsStudents",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsTeachers_IdTeacher",
                table: "SubjectsTeachers",
                column: "IdTeacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostedServiceLogs");

            migrationBuilder.DropTable(
                name: "SubjectsStudents");

            migrationBuilder.DropTable(
                name: "SubjectsTeachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
