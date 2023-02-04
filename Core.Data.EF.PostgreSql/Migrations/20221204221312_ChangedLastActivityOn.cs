using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.EF.PostgreSql.Migrations
{
    public partial class ChangedLastActivityOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bump",
                table: "Voxs",
                newName: "LastActivityOn");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_Bump",
                table: "Voxs",
                newName: "IX_Voxs_LastActivityOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastActivityOn",
                table: "Voxs",
                newName: "Bump");

            migrationBuilder.RenameIndex(
                name: "IX_Voxs_LastActivityOn",
                table: "Voxs",
                newName: "IX_Voxs_Bump");
        }
    }
}
