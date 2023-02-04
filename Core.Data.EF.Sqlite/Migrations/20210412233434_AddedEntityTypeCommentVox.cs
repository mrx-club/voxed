using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class AddedEntityTypeCommentVox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Voxs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Voxs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Comments");
        }
    }
}
