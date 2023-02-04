using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class addedIndexToBumpVox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Voxs_Bump",
                table: "Voxs",
                column: "Bump");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Voxs_Bump",
                table: "Voxs");
        }
    }
}
