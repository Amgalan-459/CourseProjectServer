using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Exercises");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Workouts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workouts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Exercises",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
