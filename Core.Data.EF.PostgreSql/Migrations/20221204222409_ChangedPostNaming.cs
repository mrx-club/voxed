using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedPostNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Voxs_VoxId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_Voxs_VoxId",
                table: "UserVoxActions");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voxs",
                table: "Voxs");

            migrationBuilder.RenameTable(
                name: "Voxs",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_PollId",
                table: "Posts",
                newName: "IX_Posts_PollId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_MediaId",
                table: "Posts",
                newName: "IX_Posts_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_LastActivityOn",
                table: "Posts",
                newName: "IX_Posts_LastActivityOn");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_CategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Posts_VoxId",
                table: "Notifications",
                column: "VoxId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Media_MediaId",
                table: "Posts",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Polls_PollId",
                table: "Posts",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoxActions_Posts_VoxId",
                table: "UserVoxActions",
                column: "VoxId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Posts_VoxId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Media_MediaId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Polls_PollId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_Posts_VoxId",
                table: "UserVoxActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Voxs");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Voxs",
                newName: "IX_Voxs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PollId",
                table: "Voxs",
                newName: "IX_Voxs_PollId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_MediaId",
                table: "Voxs",
                newName: "IX_Voxs_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_LastActivityOn",
                table: "Voxs",
                newName: "IX_Voxs_LastActivityOn");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "Voxs",
                newName: "IX_Voxs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voxs",
                table: "Voxs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Voxs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Voxs_VoxId",
                table: "Notifications",
                column: "VoxId",
                principalTable: "Voxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoxActions_Voxs_VoxId",
                table: "UserVoxActions",
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
                principalColumn: "Id");
        }
    }
}
