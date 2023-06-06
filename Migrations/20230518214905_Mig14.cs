using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class Mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Bookings",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Bookings",
                newName: "ExpirationDate");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserID",
                table: "Bookings",
                newName: "IX_Bookings_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Bookings",
                newName: "AppUserID");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Bookings",
                newName: "CreationDate");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                newName: "IX_Bookings_AppUserID");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserID",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserID",
                table: "Bookings",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
