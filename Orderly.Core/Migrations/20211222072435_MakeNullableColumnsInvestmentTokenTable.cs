using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class MakeNullableColumnsInvestmentTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_NetworkTokens_TokenId",
                table: "InvestmentToken");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                table: "InvestmentToken");

            migrationBuilder.AlterColumn<int>(
                name: "TokenId",
                table: "InvestmentToken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvestmentId",
                table: "InvestmentToken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentToken_NetworkTokens_TokenId",
                table: "InvestmentToken",
                column: "TokenId",
                principalTable: "NetworkTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                table: "InvestmentToken",
                column: "InvestmentId",
                principalTable: "UserInvestments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_NetworkTokens_TokenId",
                table: "InvestmentToken");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                table: "InvestmentToken");

            migrationBuilder.AlterColumn<int>(
                name: "TokenId",
                table: "InvestmentToken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvestmentId",
                table: "InvestmentToken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
