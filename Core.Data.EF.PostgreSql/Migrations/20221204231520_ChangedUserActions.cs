using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedUserActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Polls_PollId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_AspNetUsers_UserId",
                table: "UserVoxActions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoxActions_Posts_PostId",
                table: "UserVoxActions");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PollId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVoxActions",
                table: "UserVoxActions");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "UserVoxActions",
                newName: "UserPostActions");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_UserId_PostId",
                table: "UserPostActions",
                newName: "IX_UserPostActions_UserId_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVoxActions_PostId",
                table: "UserPostActions",
                newName: "IX_UserPostActions_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostActions",
                table: "UserPostActions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostActions_AspNetUsers_UserId",
                table: "UserPostActions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostActions_Posts_PostId",
                table: "UserPostActions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostActions_AspNetUsers_UserId",
                table: "UserPostActions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPostActions_Posts_PostId",
                table: "UserPostActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostActions",
                table: "UserPostActions");

            migrationBuilder.RenameTable(
                name: "UserPostActions",
                newName: "UserVoxActions");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostActions_UserId_PostId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_UserId_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPostActions_PostId",
                table: "UserVoxActions",
                newName: "IX_UserVoxActions_PostId");

            migrationBuilder.AddColumn<Guid>(
                name: "PollId",
                table: "Posts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVoxActions",
                table: "UserVoxActions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    OptionADescription = table.Column<string>(type: "text", nullable: true),
                    OptionAVotes = table.Column<int>(type: "integer", nullable: false),
                    OptionBDescription = table.Column<string>(type: "text", nullable: true),
                    OptionBVotes = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PollId",
                table: "Posts",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Polls_PollId",
                table: "Posts",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoxActions_AspNetUsers_UserId",
                table: "UserVoxActions",
                column: "UserId",
                principalTable: "AspNetUsers",
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
    }
}
