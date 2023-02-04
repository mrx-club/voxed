using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.MySql.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_VoxID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_AspNetUsers_UserID",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Categories_CategoryID",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_MediaID",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Polls_PollID",
                table: "Voxs");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Voxs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PollID",
                table: "Voxs",
                newName: "PollId");

            migrationBuilder.RenameColumn(
                name: "MediaID",
                table: "Voxs",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Voxs",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Voxs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_UserID",
                table: "Voxs",
                newName: "IX_Voxs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_PollID",
                table: "Voxs",
                newName: "IX_Voxs_PollId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_MediaID",
                table: "Voxs",
                newName: "IX_Voxs_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_CategoryID",
                table: "Voxs",
                newName: "IX_Voxs_CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Polls",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Media",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VoxID",
                table: "Comments",
                newName: "VoxId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MediaID",
                table: "Comments",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_VoxID",
                table: "Comments",
                newName: "IX_Comments_VoxId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MediaID",
                table: "Comments",
                newName: "IX_Comments_MediaId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Polls",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Media",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments",
                column: "VoxId",
                principalTable: "Voxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_AspNetUsers_UserId",
                table: "Voxs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Categories_CategoryId",
                table: "Voxs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Polls_PollId",
                table: "Voxs",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_AspNetUsers_UserId",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Categories_CategoryId",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Media_MediaId",
                table: "Voxs");

            migrationBuilder.DropForeignKey(
                name: "FK_Voxs_Polls_PollId",
                table: "Voxs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Voxs",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PollId",
                table: "Voxs",
                newName: "PollID");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Voxs",
                newName: "MediaID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Voxs",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Voxs",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_UserId",
                table: "Voxs",
                newName: "IX_Voxs_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_PollId",
                table: "Voxs",
                newName: "IX_Voxs_PollID");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_MediaId",
                table: "Voxs",
                newName: "IX_Voxs_MediaID");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_CategoryId",
                table: "Voxs",
                newName: "IX_Voxs_CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Polls",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Media",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "VoxId",
                table: "Comments",
                newName: "VoxID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Comments",
                newName: "MediaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_VoxId",
                table: "Comments",
                newName: "IX_Comments_VoxID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MediaId",
                table: "Comments",
                newName: "IX_Comments_MediaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Media_MediaID",
                table: "Comments",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_VoxID",
                table: "Comments",
                column: "VoxID",
                principalTable: "Voxs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_AspNetUsers_UserID",
                table: "Voxs",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Categories_CategoryID",
                table: "Voxs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Media_MediaID",
                table: "Voxs",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voxs_Polls_PollID",
                table: "Voxs",
                column: "PollID",
                principalTable: "Polls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
