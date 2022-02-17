using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddNetworkTokensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworkId = table.Column<int>(type: "int", nullable: false),
                    CreatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOnDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkTokens_MonitoringTypes_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "MonitoringTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkTokens_NetworkId",
                table: "NetworkTokens",
                column: "NetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkTokens");
        }
    }
}
