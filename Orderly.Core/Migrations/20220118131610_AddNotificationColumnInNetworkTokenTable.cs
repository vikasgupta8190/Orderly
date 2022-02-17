using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddNotificationColumnInNetworkTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNotificationSet",
                table: "NetworkTokens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowInPortfolio",
                table: "NetworkTokens",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNotificationSet",
                table: "NetworkTokens");

            migrationBuilder.DropColumn(
                name: "IsShowInPortfolio",
                table: "NetworkTokens");
        }
    }
}
