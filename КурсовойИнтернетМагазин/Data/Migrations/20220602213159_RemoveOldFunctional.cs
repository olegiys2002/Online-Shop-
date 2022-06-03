using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace КурсовойИнтернетМагазин.Data.Migrations
{
    public partial class RemoveOldFunctional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57b7a6b9-0630-45be-a2c7-e96afd1948e1", "AQAAAAEAACcQAAAAEEaiyWiqaNkSIT8DnHjomRgwA09x5hXACDo0DmCm3H8BKJql2BOVLPSMyFN0IYAsAQ==", "fa62f981-fdfd-4b83-96da-57cc1ae7569b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProduct", x => new { x.ProductsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48e0529b-329d-49b2-9943-13995a0f13f7", "AQAAAAEAACcQAAAAEDOjMjcQomAhQgsdpk/pXlUxMUq+5ltqPcOwb9YfA7XO9eCkjizuDbzjq8MKgz53Pw==", "b5e18770-9636-4d5a-9914-4cb6bfe0c9a7" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_UsersId",
                table: "ApplicationUserProduct",
                column: "UsersId");
        }
    }
}
