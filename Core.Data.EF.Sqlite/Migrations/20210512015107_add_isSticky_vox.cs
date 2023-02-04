using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class add_isSticky_vox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSticky",
                table: "Voxs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSticky",
                table: "Voxs");
        }
    }
}
