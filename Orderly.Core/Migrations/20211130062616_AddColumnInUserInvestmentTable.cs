using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddColumnInUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomLink",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistributionPortal",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomLink",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "DistributionPortal",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "UserInvestments");
        }
    }
}
