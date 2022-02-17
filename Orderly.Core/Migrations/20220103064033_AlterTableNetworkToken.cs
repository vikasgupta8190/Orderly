using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AlterTableNetworkToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NetworkTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NetworkTokens_UserId",
                table: "NetworkTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens");

            migrationBuilder.DropIndex(
                name: "IX_NetworkTokens_UserId",
                table: "NetworkTokens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NetworkTokens");
        }
    }
}
