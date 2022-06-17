using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Data.Migrations
{
    public partial class CartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4588710-c93d-45a7-a2dd-6f10714b2647", "AQAAAAEAACcQAAAAECOuW1gJcweNyZmWZSNjMopr/NIkQwvKjJPpI5AYlyyjgYNknC100VFByYk4zcomvA==", "e97c2af4-b0ec-42ed-8c3b-95751edd5ee0" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5702ce7d-30a2-486f-8408-fe7ae3d65660", "AQAAAAEAACcQAAAAEMXjX/FdLzpZw6pB64W3UX0wSE4OQ6ebZsktOk0IA5Kfd6UYvKQ/GMDEH3ShBu2Qgw==", "41410e0f-5bf5-4fb9-9a9d-c1a79409ac9b" });
        }
    }
}
