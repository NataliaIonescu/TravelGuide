using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourOffer_CityTours_CityTourID",
                table: "TourOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOffer_Offers_OfferID",
                table: "TourOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourOffer",
                table: "TourOffer");

            migrationBuilder.RenameTable(
                name: "TourOffer",
                newName: "TourOffers");

            migrationBuilder.RenameIndex(
                name: "IX_TourOffer_OfferID",
                table: "TourOffers",
                newName: "IX_TourOffers_OfferID");

            migrationBuilder.RenameIndex(
                name: "IX_TourOffer_CityTourID",
                table: "TourOffers",
                newName: "IX_TourOffers_CityTourID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourOffers",
                table: "TourOffers",
                column: "TourOfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_TourOffers_CityTours_CityTourID",
                table: "TourOffers",
                column: "CityTourID",
                principalTable: "CityTours",
                principalColumn: "CityTourID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourOffers_Offers_OfferID",
                table: "TourOffers",
                column: "OfferID",
                principalTable: "Offers",
                principalColumn: "OfferID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourOffers_CityTours_CityTourID",
                table: "TourOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_TourOffers_Offers_OfferID",
                table: "TourOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourOffers",
                table: "TourOffers");

            migrationBuilder.RenameTable(
                name: "TourOffers",
                newName: "TourOffer");

            migrationBuilder.RenameIndex(
                name: "IX_TourOffers_OfferID",
                table: "TourOffer",
                newName: "IX_TourOffer_OfferID");

            migrationBuilder.RenameIndex(
                name: "IX_TourOffers_CityTourID",
                table: "TourOffer",
                newName: "IX_TourOffer_CityTourID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourOffer",
                table: "TourOffer",
                column: "TourOfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_TourOffer_CityTours_CityTourID",
                table: "TourOffer",
                column: "CityTourID",
                principalTable: "CityTours",
                principalColumn: "CityTourID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourOffer_Offers_OfferID",
                table: "TourOffer",
                column: "OfferID",
                principalTable: "Offers",
                principalColumn: "OfferID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
