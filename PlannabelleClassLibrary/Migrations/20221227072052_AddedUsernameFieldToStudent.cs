using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannabelleClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsernameFieldToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Students");
        }
    }
}
