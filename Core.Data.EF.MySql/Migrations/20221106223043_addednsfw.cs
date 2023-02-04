using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.MySql.Migrations
{
    public partial class addednsfw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Nsfw",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nsfw",
                table: "Categories");
        }
    }
}
