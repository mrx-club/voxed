using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedMediaIdOnEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_AttachmentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_AttachmentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Bump",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Comments",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AttachmentId",
                table: "Comments",
                newName: "IX_Comments_MediaId");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Categories",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_AttachmentId",
                table: "Categories",
                newName: "IX_Categories_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_MediaId",
                table: "Categories",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_MediaId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Comments",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MediaId",
                table: "Comments",
                newName: "IX_Comments_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Categories",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MediaId",
                table: "Categories",
                newName: "IX_Categories_AttachmentId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Bump",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_AttachmentId",
                table: "Categories",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_AttachmentId",
                table: "Comments",
                column: "AttachmentId",
                principalTable: "Media",
                principalColumn: "Id");
        }
    }
}
