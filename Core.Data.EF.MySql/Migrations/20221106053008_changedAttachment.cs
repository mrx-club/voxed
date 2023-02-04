using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.MySql.Migrations
{
    public partial class changedAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs");

            migrationBuilder.DropIndex(
                name: "IX_Voxs_Hash",
                table: "Voxs");

            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Voxs");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Voxs",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_MediaId",
                table: "Voxs",
                newName: "IX_Voxs_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Comments",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MediaId",
                table: "Comments",
                newName: "IX_Comments_AttachmentId");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Media",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExternalUrl",
                table: "Media",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Media",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_AttachmentId",
                table: "Comments",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_AttachmentId",
                table: "Voxs",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_AttachmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_AttachmentId",
                table: "Voxs");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ExternalUrl",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Voxs",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_AttachmentId",
                table: "Voxs",
                newName: "IX_Voxs_MediaId");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Comments",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AttachmentId",
                table: "Comments",
                newName: "IX_Comments_MediaId");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Voxs",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_Hash",
                table: "Voxs",
                column: "Hash",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
