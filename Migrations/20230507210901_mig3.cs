using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Offers",
                newName: "HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_HotelId",
                table: "Offers",
                newName: "IX_Offers_HotelID");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "Offers",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_HotelID",
                table: "Offers",
                newName: "IX_Offers_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelId",
                table: "Offers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
