using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class updatedentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UpdatedOn",
                table: "Voxs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedOn",
                table: "UserVoxActions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedOn",
                table: "Polls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailKey",
                table: "Media",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedOn",
                table: "Media",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedOn",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Voxs");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "UserVoxActions");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "ThumbnailKey",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");
        }
    }
}
