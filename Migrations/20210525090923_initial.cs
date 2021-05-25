using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ObeSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lower_marks = table.Column<int>(type: "int", nullable: false),
                    Higher_marks = table.Column<int>(type: "int", nullable: false),
                    Grade_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gpa = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_marks = table.Column<float>(type: "real", nullable: false),
                    Batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    End_marks = table.Column<int>(type: "int", nullable: false),
                    Ca_marks = table.Column<int>(type: "int", nullable: false),
                    Min_end_marks = table.Column<float>(type: "real", nullable: false),
                    Min_ca_marks = table.Column<float>(type: "real", nullable: false),
                    Min_total_marks = table.Column<float>(type: "real", nullable: false),
                    Min_po_marks = table.Column<float>(type: "real", nullable: false),
                    Min_lo_marks = table.Column<float>(type: "real", nullable: false),
                    Min_attendance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Module_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Module_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Lecturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThresholdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Thresholds_ThresholdId",
                        column: x => x.ThresholdId,
                        principalTable: "Thresholds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assessment_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assessment_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marks = table.Column<int>(type: "int", nullable: false),
                    Student_marks = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lolists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lo_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lo_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lolists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lolists_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Po_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Po_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polists_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentStudents",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assessment_marks = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentStudents", x => new { x.AssessmentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_AssessmentStudents_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentLos",
                columns: table => new
                {
                    LolistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentLos", x => new { x.LolistId, x.AssessmentId });
                    table.ForeignKey(
                        name: "FK_AssessmentLos_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentLos_Lolists_LolistId",
                        column: x => x.LolistId,
                        principalTable: "Lolists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLolists",
                columns: table => new
                {
                    LolistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lo_marks = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLolists", x => new { x.StudentId, x.LolistId });
                    table.ForeignKey(
                        name: "FK_StudentLolists_Lolists_LolistId",
                        column: x => x.LolistId,
                        principalTable: "Lolists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLolists_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LolistPos",
                columns: table => new
                {
                    LolistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolistPos", x => new { x.LolistId, x.PolistId });
                    table.ForeignKey(
                        name: "FK_LolistPos_Lolists_LolistId",
                        column: x => x.LolistId,
                        principalTable: "Lolists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LolistPos_Polists_PolistId",
                        column: x => x.PolistId,
                        principalTable: "Polists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentLos_AssessmentId",
                table: "AssessmentLos",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleId",
                table: "Assessments",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentStudents_StudentId",
                table: "AssessmentStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LolistPos_PolistId",
                table: "LolistPos",
                column: "PolistId");

            migrationBuilder.CreateIndex(
                name: "IX_Lolists_ModuleId",
                table: "Lolists",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_GradeId",
                table: "Modules",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ThresholdId",
                table: "Modules",
                column: "ThresholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Polists_ModuleId",
                table: "Polists",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLolists_LolistId",
                table: "StudentLolists",
                column: "LolistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentLos");

            migrationBuilder.DropTable(
                name: "AssessmentStudents");

            migrationBuilder.DropTable(
                name: "LolistPos");

            migrationBuilder.DropTable(
                name: "StudentLolists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Polists");

            migrationBuilder.DropTable(
                name: "Lolists");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Thresholds");
        }
    }
}
