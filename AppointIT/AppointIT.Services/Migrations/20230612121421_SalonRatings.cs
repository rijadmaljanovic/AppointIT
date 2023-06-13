using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointIT.Services.Migrations
{
    public partial class SalonRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatumOcjene",
                table: "SalonRatings",
                newName: "RatingDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingDate",
                table: "SalonRatings",
                newName: "DatumOcjene");
        }
    }
}
