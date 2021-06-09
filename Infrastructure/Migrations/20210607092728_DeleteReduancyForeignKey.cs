using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DeleteReduancyForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Movie_MovieId",
                table: "Crew");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Movie_MovieId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_MovieId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Crew_MovieId",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Crew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Crew",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_MovieId",
                table: "User",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MovieId",
                table: "Crew",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Movie_MovieId",
                table: "Crew",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Movie_MovieId",
                table: "User",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
