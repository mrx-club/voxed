using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.MySql.Migrations
{
    public partial class AddedIsStickyComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSticky",
                table: "Comments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSticky",
                table: "Comments");
        }
    }
}
