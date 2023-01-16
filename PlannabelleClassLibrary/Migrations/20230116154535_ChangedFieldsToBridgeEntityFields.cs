using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannabelleClassLibrary.Migrations
{
    public partial class ChangedFieldsToBridgeEntityFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Modules_ModuleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Semesters_SemesterId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Enrollments",
                newName: "StudentSemesterId");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Enrollments",
                newName: "StudentModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_SemesterId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentSemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_ModuleId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentModuleId");

            migrationBuilder.CreateTable(
                name: "StudentModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    SelfStudyHoursPerWeek = table.Column<double>(type: "float", nullable: false),
                    SelfStudyHoursRemaining = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentModule_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentModule_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentModule_ModuleId",
                table: "StudentModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModule_StudentId",
                table: "StudentModule",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_StudentModule_StudentModuleId",
                table: "Enrollments",
                column: "StudentModuleId",
                principalTable: "StudentModule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_StudentSemesters_StudentSemesterId",
                table: "Enrollments",
                column: "StudentSemesterId",
                principalTable: "StudentSemesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudentModule_StudentModuleId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudentSemesters_StudentSemesterId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentModule");

            migrationBuilder.RenameColumn(
                name: "StudentSemesterId",
                table: "Enrollments",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "StudentModuleId",
                table: "Enrollments",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentSemesterId",
                table: "Enrollments",
                newName: "IX_Enrollments_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentModuleId",
                table: "Enrollments",
                newName: "IX_Enrollments_ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Modules_ModuleId",
                table: "Enrollments",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Semesters_SemesterId",
                table: "Enrollments",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
