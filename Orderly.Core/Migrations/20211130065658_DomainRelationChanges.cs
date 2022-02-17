using Microsoft.EntityFrameworkCore.Migrations;

namespace Orderly.Core.Migrations
{
    public partial class DomainRelationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_UserGroup_GroupId",
                table: "UserContact");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "UserContact",
                newName: "UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_GroupId",
                table: "UserContact",
                newName: "IX_UserContact_UserGroupId");

            migrationBuilder.CreateTable(
                name: "UserContactGroupMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactGroupMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactGroupMapping_UserContact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "UserContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserContactGroupMapping_UserGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserContactGroupMapping_ContactId",
                table: "UserContactGroupMapping",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactGroupMapping_GroupId",
                table: "UserContactGroupMapping",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContact_UserGroup_UserGroupId",
                table: "UserContact",
                column: "UserGroupId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_UserGroup_UserGroupId",
                table: "UserContact");

            migrationBuilder.DropTable(
                name: "UserContactGroupMapping");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserContact",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_UserGroupId",
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
    }
}
