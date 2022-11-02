using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannabelleClassLibrary.Migrations
{
    public partial class moved_fields_to_enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassHoursPerWeek",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursPerWeek",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursRemaingForWeek",
                table: "Module");

            migrationBuilder.AddColumn<int>(
                name: "ClassHoursPerWeek",
                table: "Enrollment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelfStudyHoursPerWeek",
                table: "Enrollment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SelfStudyHoursRemaingForWeek",
                table: "Enrollment",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassHoursPerWeek",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursPerWeek",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "SelfStudyHoursRemaingForWeek",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "ClassHoursPerWeek",
                table: "Module",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelfStudyHoursPerWeek",
                table: "Module",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SelfStudyHoursRemaingForWeek",
                table: "Module",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
