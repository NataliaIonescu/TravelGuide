using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class Mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Bookings",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                newName: "IX_Bookings_AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Bookings",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserID",
                table: "Bookings",
                newName: "IX_Bookings_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserID",
                table: "Bookings",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
