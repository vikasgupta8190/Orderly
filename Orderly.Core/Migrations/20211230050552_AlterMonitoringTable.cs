using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AlterMonitoringTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitorings_NetworkTokens_NetworkTokenId",
                table: "Monitorings");

            migrationBuilder.DropIndex(
                name: "IX_Monitorings_NetworkTokenId",
                table: "Monitorings");

            migrationBuilder.DropColumn(
                name: "NetworkTokenId",
                table: "Monitorings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Monitorings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_UserId",
                table: "Monitorings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorings_AspNetUsers_UserId",
                table: "Monitorings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitorings_AspNetUsers_UserId",
                table: "Monitorings");

            migrationBuilder.DropIndex(
                name: "IX_Monitorings_UserId",
                table: "Monitorings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Monitorings");

            migrationBuilder.AddColumn<int>(
                name: "NetworkTokenId",
                table: "Monitorings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_NetworkTokenId",
                table: "Monitorings",
                column: "NetworkTokenId",
                unique: true,
                filter: "[NetworkTokenId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorings_NetworkTokens_NetworkTokenId",
                table: "Monitorings",
                column: "NetworkTokenId",
                principalTable: "NetworkTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
