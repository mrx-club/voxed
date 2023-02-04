using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class AddUserVoxActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVoxActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VoxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsFollowed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHidden = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false)
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
                        principalColumn: "ID",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVoxActions");
        }
    }
}
