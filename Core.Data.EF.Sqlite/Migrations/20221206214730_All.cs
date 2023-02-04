using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_AttachmentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_AttachmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Voxs_VoxId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "UserVoxActions");

            migrationBuilder.DropTable(
                name: "Voxs");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropColumn(
                name: "Bump",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "VoxId",
                table: "Notifications",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_VoxId",
                table: "Notifications",
                newName: "IX_Notifications_PostId");

            migrationBuilder.RenameColumn(
                name: "VoxId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Comments",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_VoxId",
                table: "Comments",
                newName: "IX_Comments_PostId");

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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSticky = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastActivityOn = table.Column<long>(type: "INTEGER", nullable: false),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdatedOn = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPostActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsFollowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHidden = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdatedOn = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPostActions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostActions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LastActivityOn",
                table: "Posts",
                column: "LastActivityOn");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MediaId",
                table: "Posts",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostActions_PostId",
                table: "UserPostActions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostActions_UserId_PostId",
                table: "UserPostActions",
                columns: new[] { "UserId", "PostId" },
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Posts_PostId",
                table: "Notifications",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_MediaId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Media_MediaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Posts_PostId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "UserPostActions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Notifications",
                newName: "VoxId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_PostId",
                table: "Notifications",
                newName: "IX_Notifications_VoxId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "VoxId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Comments",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_VoxId");

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

            migrationBuilder.AddColumn<long>(
                name: "Bump",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    OptionADescription = table.Column<string>(type: "TEXT", nullable: true),
                    OptionAVotes = table.Column<int>(type: "INTEGER", nullable: false),
                    OptionBDescription = table.Column<string>(type: "TEXT", nullable: true),
                    OptionBVotes = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedOn = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voxs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    PollId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Bump = table.Column<long>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsSticky = table.Column<bool>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UpdatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voxs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voxs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voxs_Media_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voxs_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserVoxActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VoxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFollowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHidden = table.Column<bool>(type: "INTEGER", nullable: false),
                    UpdatedOn = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVoxActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVoxActions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVoxActions_Voxs_VoxId",
                        column: x => x.VoxId,
                        principalTable: "Voxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVoxActions_UserId_VoxId",
                table: "UserVoxActions",
                columns: new[] { "UserId", "VoxId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserVoxActions_VoxId",
                table: "UserVoxActions",
                column: "VoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_AttachmentId",
                table: "Voxs",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_Bump",
                table: "Voxs",
                column: "Bump");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_CategoryId",
                table: "Voxs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_PollId",
                table: "Voxs",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_UserId",
                table: "Voxs",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments",
                column: "VoxId",
                principalTable: "Voxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Voxs_VoxId",
                table: "Notifications",
                column: "VoxId",
                principalTable: "Voxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
