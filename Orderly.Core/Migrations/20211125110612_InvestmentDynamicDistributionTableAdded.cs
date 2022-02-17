using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class InvestmentDynamicDistributionTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_AspNetUsers_UserId1",
                table: "UserInvestments");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_UserId1",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserInvestments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InvestmentDynamicDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TGE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peroid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TokenPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lookup = table.Column<bool>(type: "bit", nullable: false),
                    InvestmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentDynamicDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentDynamicDistributions_UserInvestments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "UserInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_UserId",
                table: "UserInvestments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentDynamicDistributions_InvestmentId",
                table: "InvestmentDynamicDistributions",
                column: "InvestmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_AspNetUsers_UserId",
                table: "UserInvestments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_AspNetUsers_UserId",
                table: "UserInvestments");

            migrationBuilder.DropTable(
                name: "InvestmentDynamicDistributions");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_UserId",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserInvestments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_UserId1",
                table: "UserInvestments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_AspNetUsers_UserId1",
                table: "UserInvestments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
