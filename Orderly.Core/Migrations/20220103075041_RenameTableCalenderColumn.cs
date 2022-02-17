using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class RenameTableCalenderColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndsIn",
                table: "Calendars");

            migrationBuilder.RenameColumn(
                name: "StartsIn",
                table: "Calendars",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Calendars",
                newName: "StartsIn");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndsIn",
                table: "Calendars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
