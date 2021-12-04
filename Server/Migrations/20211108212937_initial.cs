using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[] { 1, "book", "Books", "books" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[] { 2, "aperture", "Video Games", "video-games" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[] { 3, "monitor", "Electronics", "electronics" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "OriginalPrice", "Price", "Title" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Book number one", "data:image/jpeg;base64,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", false, false, 19.99m, 10.99m, "Book #1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "OriginalPrice", "Price", "Title" },
                values: new object[] { 2, 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Game number one", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Video-Game-Controller-Icon-IDV-green.svg/2048px-Video-Game-Controller-Icon-IDV-green.svg.png", false, false, 9.90m, 9.90m, "Game #1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "OriginalPrice", "Price", "Title" },
                values: new object[] { 3, 3, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Console number one", "https://m.media-amazon.com/images/I/619Bmcg-EIL.jpg", false, false, 1110.90m, 1000.90m, "Console #1" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
