using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateMovieCrewTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrews_Crew_CrewId",
                table: "MovieCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrews_Movie_MovieId",
                table: "MovieCrews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCrews",
                table: "MovieCrews");

            migrationBuilder.RenameTable(
                name: "MovieCrews",
                newName: "MovieCrew");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCrews_CrewId",
                table: "MovieCrew",
                newName: "IX_MovieCrew_CrewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCrew",
                table: "MovieCrew",
                columns: new[] { "MovieId", "CrewId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrew_Crew_CrewId",
                table: "MovieCrew",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrew_Movie_MovieId",
                table: "MovieCrew",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrew_Crew_CrewId",
                table: "MovieCrew");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrew_Movie_MovieId",
                table: "MovieCrew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCrew",
                table: "MovieCrew");

            migrationBuilder.RenameTable(
                name: "MovieCrew",
                newName: "MovieCrews");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCrew_CrewId",
                table: "MovieCrews",
                newName: "IX_MovieCrews_CrewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCrews",
                table: "MovieCrews",
                columns: new[] { "MovieId", "CrewId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrews_Crew_CrewId",
                table: "MovieCrews",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrews_Movie_MovieId",
                table: "MovieCrews",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
