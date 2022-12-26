using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannabelleClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedSelfStudyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Semesters_SemseterId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "SemseterId",
                table: "Enrollments",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_SemseterId",
                table: "Enrollments",
                newName: "IX_Enrollments_SemesterId");

            migrationBuilder.AddColumn<double>(
                name: "SelfStudyHoursPerWeek",
                table: "Enrollments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SelfStudyHoursRemaining",
                table: "Enrollments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Semesters_SemesterId",
                table: "Enrollments",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Semesters_SemesterId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursPerWeek",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursRemaining",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Enrollments",
                newName: "SemseterId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_SemesterId",
                table: "Enrollments",
                newName: "IX_Enrollments_SemseterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Semesters_SemseterId",
                table: "Enrollments",
                column: "SemseterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
