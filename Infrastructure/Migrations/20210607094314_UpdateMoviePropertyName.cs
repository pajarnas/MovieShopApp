using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateMoviePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Movie",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ReleaseOn",
                table: "Movie",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Movie",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Movie",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Movie",
                newName: "ReleaseOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Movie",
                newName: "CreatedOn");
        }
    }
}
