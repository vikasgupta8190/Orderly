using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class RemoveInvestmentTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentToken");

            migrationBuilder.AddColumn<int>(
                name: "TokenId",
                table: "UserInvestments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_TokenId",
                table: "UserInvestments",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_NetworkTokens_TokenId",
                table: "UserInvestments",
                column: "TokenId",
                principalTable: "NetworkTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_NetworkTokens_TokenId",
                table: "UserInvestments");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_TokenId",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "UserInvestments");

            migrationBuilder.CreateTable(
                name: "InvestmentToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestmentId = table.Column<int>(type: "int", nullable: true),
                    TokenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentToken_NetworkTokens_TokenId",
                        column: x => x.TokenId,
                        principalTable: "NetworkTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvestmentToken_UserInvestments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "UserInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentToken_InvestmentId",
                table: "InvestmentToken",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentToken_TokenId",
                table: "InvestmentToken",
                column: "TokenId");
        }
    }
}
