using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannabelleClassLibrary.Migrations
{
    public partial class ChangedUserIdToStudentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentSemesters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StudentSemesters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
