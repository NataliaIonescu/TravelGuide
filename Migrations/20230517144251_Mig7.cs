using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class Mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CityTours");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Offers",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CityTours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CityTours");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "CityTours",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
