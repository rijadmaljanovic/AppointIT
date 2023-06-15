using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointIT.Services.Migrations
{
    public partial class SalonRatingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRatings");

            migrationBuilder.CreateTable(
                name: "SalonRatings",
                columns: table => new
                {
                    SalonRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonRatings", x => x.SalonRatingId);
                    table.ForeignKey(
                        name: "FK_SalonRatings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalonRatings_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalonRatings_CustomerId",
                table: "SalonRatings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalonRatings_SalonId",
                table: "SalonRatings",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalonRatings");

            migrationBuilder.CreateTable(
                name: "ServiceRatings",
                columns: table => new
                {
                    ServiceRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRatings", x => x.ServiceRatingId);
                    table.ForeignKey(
                        name: "FK_ServiceRatings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRatings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRatings_CustomerId",
                table: "ServiceRatings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRatings_ServiceId",
                table: "ServiceRatings",
                column: "ServiceId");
        }
    }
}
