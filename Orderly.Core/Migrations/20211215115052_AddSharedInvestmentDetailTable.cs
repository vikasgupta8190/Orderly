using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddSharedInvestmentDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SharedInvestmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedInvestmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedInvestmentDetails_UserContact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "UserContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedInvestmentDetails_UserInvestments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "UserInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharedInvestmentDetails_ContactId",
                table: "SharedInvestmentDetails",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedInvestmentDetails_InvestmentId",
                table: "SharedInvestmentDetails",
                column: "InvestmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedInvestmentDetails");
        }
    }
}
