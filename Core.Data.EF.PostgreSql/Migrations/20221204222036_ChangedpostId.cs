using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedpostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_VoxId",
                table: "Comments");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Voxs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Voxs_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VoxId",
                table: "Comments",
                column: "VoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Voxs_VoxId",
                table: "Comments",
                column: "VoxId",
                principalTable: "Voxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
