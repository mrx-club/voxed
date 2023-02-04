using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Sqlite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OptionADescription = table.Column<string>(nullable: true),
                    OptionBDescription = table.Column<string>(nullable: true),
                    OptionAVotes = table.Column<int>(nullable: false),
                    OptionBVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<long>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: false),
                    MediaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voxs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Content = table.Column<string>(maxLength: 1000, nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    MediaID = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<long>(nullable: false),
                    Bump = table.Column<long>(nullable: false),
                    PollID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voxs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voxs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voxs_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voxs_Polls_PollID",
                        column: x => x.PollID,
                        principalTable: "Polls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voxs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    VoxID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    MediaID = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedOn = table.Column<long>(nullable: false),
                    Bump = table.Column<long>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Media_MediaID",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Voxs_VoxID",
                        column: x => x.VoxID,
                        principalTable: "Voxs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MediaID",
                table: "Categories",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Hash",
                table: "Comments",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MediaID",
                table: "Comments",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VoxID",
                table: "Comments",
                column: "VoxID");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_CategoryID",
                table: "Voxs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_Hash",
                table: "Voxs",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_MediaID",
                table: "Voxs",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_PollID",
                table: "Voxs",
                column: "PollID");

            migrationBuilder.CreateIndex(
                name: "IX_Voxs_UserID",
                table: "Voxs",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Voxs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
