using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class RenameColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_UserGroup_GroupsId",
                table: "UserContact");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "UserContact",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_GroupsId",
                table: "UserContact",
                newName: "IX_UserContact_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContact_UserGroup_GroupId",
                table: "UserContact",
                column: "GroupId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_UserGroup_GroupId",
                table: "UserContact");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "UserContact",
                newName: "GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_GroupId",
                table: "UserContact",
                newName: "IX_UserContact_GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContact_UserGroup_GroupsId",
                table: "UserContact",
                column: "GroupsId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
