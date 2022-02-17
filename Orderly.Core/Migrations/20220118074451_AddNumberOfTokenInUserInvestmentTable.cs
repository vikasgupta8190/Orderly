using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddNumberOfTokenInUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfToken",
                table: "UserInvestments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfToken",
                table: "UserInvestments");
        }
    }
}
