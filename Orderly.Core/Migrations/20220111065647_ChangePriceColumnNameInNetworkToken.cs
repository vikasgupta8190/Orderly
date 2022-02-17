using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class ChangePriceColumnNameInNetworkToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentPrice",
                table: "NetworkTokens",
                newName: "CurrentPriceUSD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentPriceUSD",
                table: "NetworkTokens",
                newName: "CurrentPrice");
        }
    }
}
