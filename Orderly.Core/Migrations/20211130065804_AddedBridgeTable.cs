using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class AddedBridgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContactGroupMapping_UserContact_ContactId",
                table: "UserContactGroupMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContactGroupMapping_UserGroup_GroupId",
                table: "UserContactGroupMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContactGroupMapping",
                table: "UserContactGroupMapping");

            migrationBuilder.RenameTable(
                name: "UserContactGroupMapping",
                newName: "UserContactGroupMappings");

            migrationBuilder.RenameIndex(
                name: "IX_UserContactGroupMapping_GroupId",
                table: "UserContactGroupMappings",
                newName: "IX_UserContactGroupMappings_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContactGroupMapping_ContactId",
                table: "UserContactGroupMappings",
                newName: "IX_UserContactGroupMappings_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContactGroupMappings",
                table: "UserContactGroupMappings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactGroupMappings_UserContact_ContactId",
                table: "UserContactGroupMappings",
                column: "ContactId",
                principalTable: "UserContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactGroupMappings_UserGroup_GroupId",
                table: "UserContactGroupMappings",
                column: "GroupId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContactGroupMappings_UserContact_ContactId",
                table: "UserContactGroupMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContactGroupMappings_UserGroup_GroupId",
                table: "UserContactGroupMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContactGroupMappings",
                table: "UserContactGroupMappings");

            migrationBuilder.RenameTable(
                name: "UserContactGroupMappings",
                newName: "UserContactGroupMapping");

            migrationBuilder.RenameIndex(
                name: "IX_UserContactGroupMappings_GroupId",
                table: "UserContactGroupMapping",
                newName: "IX_UserContactGroupMapping_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContactGroupMappings_ContactId",
                table: "UserContactGroupMapping",
                newName: "IX_UserContactGroupMapping_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContactGroupMapping",
                table: "UserContactGroupMapping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactGroupMapping_UserContact_ContactId",
                table: "UserContactGroupMapping",
                column: "ContactId",
                principalTable: "UserContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactGroupMapping_UserGroup_GroupId",
                table: "UserContactGroupMapping",
                column: "GroupId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
