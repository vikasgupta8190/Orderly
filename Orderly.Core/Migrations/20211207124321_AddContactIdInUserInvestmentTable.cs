using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddContactIdInUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "UserInvestments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_ContactId",
                table: "UserInvestments",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_UserContact_ContactId",
                table: "UserInvestments",
                column: "ContactId",
                principalTable: "UserContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_UserContact_ContactId",
                table: "UserInvestments");

            migrationBuilder.DropIndex(
                name: "IX_UserInvestments_ContactId",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "UserInvestments");
        }
    }
}
