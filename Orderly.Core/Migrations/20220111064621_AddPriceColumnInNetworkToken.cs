using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddPriceColumnInNetworkToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AllTimeHighValue",
                table: "NetworkTokens",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AllTimeLowValue",
                table: "NetworkTokens",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentPrice",
                table: "NetworkTokens",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllTimeHighValue",
                table: "NetworkTokens");

            migrationBuilder.DropColumn(
                name: "AllTimeLowValue",
                table: "NetworkTokens");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "NetworkTokens");
        }
    }
}
