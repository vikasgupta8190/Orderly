using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class ChangeColumnNameInNetworkTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyRateDiff",
                table: "NetworkTokens",
                newName: "Price24HrsDifference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price24HrsDifference",
                table: "NetworkTokens",
                newName: "DailyRateDiff");
        }
    }
}
