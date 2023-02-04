using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedPostIdUserActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Posts_VoxId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_Posts_VoxId",
                table: "UserVoxActions");

            migrationBuilder.RenameColumn(
                name: "VoxId",
                table: "UserVoxActions",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_VoxId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_UserId_VoxId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_UserId_PostId");

            migrationBuilder.RenameColumn(
                name: "VoxId",
                table: "Notifications",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_VoxId",
                table: "Notifications",
                newName: "IX_Notifications_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Posts_PostId",
                table: "Notifications",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoxActions_Posts_PostId",
                table: "UserVoxActions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Posts_PostId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_Posts_PostId",
                table: "UserVoxActions");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "UserVoxActions",
                newName: "VoxId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_UserId_PostId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_UserId_VoxId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_PostId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_VoxId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Notifications",
                newName: "VoxId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_PostId",
                table: "Notifications",
                newName: "IX_Notifications_VoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Posts_VoxId",
                table: "Notifications",
                column: "VoxId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoxActions_Posts_VoxId",
                table: "UserVoxActions",
                column: "VoxId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
