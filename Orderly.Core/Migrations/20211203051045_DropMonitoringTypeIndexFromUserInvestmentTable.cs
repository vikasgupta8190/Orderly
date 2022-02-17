using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class DropMonitoringTypeIndexFromUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId",
                unique: true);
        }
    }
}
