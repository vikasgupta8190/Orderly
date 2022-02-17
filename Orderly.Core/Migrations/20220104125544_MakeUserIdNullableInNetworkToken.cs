using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class MakeUserIdNullableInNetworkToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "NetworkTokens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "NetworkTokens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkTokens_AspNetUsers_UserId",
                table: "NetworkTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
