using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.MySql.Migrations
{
    public partial class AddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_MediaID",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MediaType",
                table: "Media",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "MediaID",
                table: "Categories",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MediaID",
                table: "Categories",
                newName: "IX_Categories_AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_AttachmentId",
                table: "Categories",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_AttachmentId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Media",
                newName: "MediaType");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Categories",
                newName: "MediaID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_AttachmentId",
                table: "Categories",
                newName: "IX_Categories_MediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_MediaID",
                table: "Categories",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
