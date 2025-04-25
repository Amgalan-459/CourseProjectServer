using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsersAndAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Trainers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Trainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Admins");
        }
    }
}
