using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.MySql.Migrations
{
    public partial class AddUserVoxActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVoxActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VoxId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsFollowed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFavorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
