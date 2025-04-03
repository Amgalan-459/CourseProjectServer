using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Trainers_TrainerId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TrainerId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Workouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainerId",
                table: "Workouts",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Trainers_TrainerId",
                table: "Workouts",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }
    }
}
