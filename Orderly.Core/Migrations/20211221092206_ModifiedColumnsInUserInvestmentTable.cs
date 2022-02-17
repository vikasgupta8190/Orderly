using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class ModifiedColumnsInUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "UserInvestments");

            migrationBuilder.RenameColumn(
                name: "EtherValue",
                table: "UserInvestments",
                newName: "InvestedQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvestedQuantity",
                table: "UserInvestments",
                newName: "EtherValue");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "UserInvestments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
