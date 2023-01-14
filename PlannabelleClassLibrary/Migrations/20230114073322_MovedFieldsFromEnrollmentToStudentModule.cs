using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannabelleClassLibrary.Migrations
{
    public partial class MovedFieldsFromEnrollmentToStudentModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelfStudyHoursPerWeek",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursRemaining",
                table: "Enrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
