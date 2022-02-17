using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class addNetworkIdColumnInUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_MonitoringTypes_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<int>(
                name: "MonitoringTypeId",
                table: "UserInvestments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_MonitoringTypes_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId",
                principalTable: "MonitoringTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_MonitoringTypes_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.DropTable(
                name: "UserContactGroupMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<int>(
                name: "MonitoringTypeId",
                table: "UserInvestments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_MonitoringTypes_MonitoringTypeId",
                table: "UserInvestments",
                column: "MonitoringTypeId",
                principalTable: "MonitoringTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
