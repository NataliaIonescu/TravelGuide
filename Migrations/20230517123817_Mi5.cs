using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class Mi5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourOffers");

            migrationBuilder.DropTable(
                name: "UserOffers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityTourID",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Itinerary",
                table: "CityTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CityTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Offers_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "OfferID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CityTourID",
                table: "Offers",
                column: "CityTourID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfferID",
                table: "Bookings",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_CityTours_CityTourID",
                table: "Offers",
                column: "CityTourID",
                principalTable: "CityTours",
                principalColumn: "CityTourID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_CityTours_CityTourID",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CityTourID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CityTourID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Itinerary",
                table: "CityTours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CityTours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TourOffers",
                columns: table => new
                {
                    TourOfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityTourID = table.Column<int>(type: "int", nullable: false),
                    OfferID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOffers", x => x.TourOfferID);
                    table.ForeignKey(
                        name: "FK_TourOffers_CityTours_CityTourID",
                        column: x => x.CityTourID,
                        principalTable: "CityTours",
                        principalColumn: "CityTourID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourOffers_Offers_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "OfferID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOffers",
                columns: table => new
                {
                    UserOfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOffers", x => x.UserOfferID);
                    table.ForeignKey(
                        name: "FK_UserOffers_Offers_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "OfferID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOffers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourOffers_CityTourID",
                table: "TourOffers",
                column: "CityTourID");

            migrationBuilder.CreateIndex(
                name: "IX_TourOffers_OfferID",
                table: "TourOffers",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOffers_OfferID",
                table: "UserOffers",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOffers_UserID",
                table: "UserOffers",
                column: "UserID");
        }
    }
}
