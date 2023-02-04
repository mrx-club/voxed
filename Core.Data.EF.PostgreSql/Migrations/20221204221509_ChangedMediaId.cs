using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedMediaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_AttachmentId",
                table: "Voxs");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Voxs",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_AttachmentId",
                table: "Voxs",
                newName: "IX_Voxs_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Voxs",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_MediaId",
                table: "Voxs",
                newName: "IX_Voxs_AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_AttachmentId",
                table: "Voxs",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
