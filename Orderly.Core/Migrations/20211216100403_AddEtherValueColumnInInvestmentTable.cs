using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddEtherValueColumnInInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EtherValue",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EtherValue",
                table: "UserInvestments");
        }
    }
}
