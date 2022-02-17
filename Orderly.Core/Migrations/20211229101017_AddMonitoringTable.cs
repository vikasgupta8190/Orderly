using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddMonitoringTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncommingTokenNotificationEvent = table.Column<bool>(type: "bit", nullable: false),
                    TokenGenerationNotificationEvent = table.Column<bool>(type: "bit", nullable: false),
                    NetworkTokenId = table.Column<int>(type: "int", nullable: true),
                    PortfolioMonitoringId = table.Column<int>(type: "int", nullable: true),
                    ShowInPortfolio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitorings_NetworkTokens_NetworkTokenId",
                        column: x => x.NetworkTokenId,
                        principalTable: "NetworkTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monitorings_PortfolioMonitorings_PortfolioMonitoringId",
                        column: x => x.PortfolioMonitoringId,
                        principalTable: "PortfolioMonitorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_NetworkTokenId",
                table: "Monitorings",
                column: "NetworkTokenId",
                unique: true,
                filter: "[NetworkTokenId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_PortfolioMonitoringId",
                table: "Monitorings",
                column: "PortfolioMonitoringId",
                unique: true,
                filter: "[PortfolioMonitoringId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitorings");
        }
    }
}
