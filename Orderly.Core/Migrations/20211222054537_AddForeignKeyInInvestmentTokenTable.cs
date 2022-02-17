using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddForeignKeyInInvestmentTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InvestmentToken_InvestmentId",
                table: "InvestmentToken",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentToken_TokenId",
                table: "InvestmentToken",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentToken_NetworkTokens_TokenId",
                table: "InvestmentToken",
                column: "TokenId",
                principalTable: "NetworkTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                table: "InvestmentToken",
                column: "InvestmentId",
                principalTable: "UserInvestments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_NetworkTokens_TokenId",
                table: "InvestmentToken");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                table: "InvestmentToken");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentToken_InvestmentId",
                table: "InvestmentToken");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentToken_TokenId",
                table: "InvestmentToken");
        }
    }
}
