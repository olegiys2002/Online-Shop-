using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Data.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "b407441d-2ef6-4af7-8f1a-ce4e93ab979d", "ApplicationUser", "oa6092698@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIkGm32KxoNBxj8J+Ks8KK7L3a0E1OepSBBYGMWgUtNu+mSed0FJYj3lvdKNXS3GfQ==", null, false, "54a4d7d9-746d-4af3-9e08-85a966a0c5be", false, "Admin" });

            migrationBuilder.InsertData(
                  table: "AspNetUserRoles",
                  columns: new[] { "RoleId", "UserId" },
                  values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_UsersId",
                table: "ApplicationUserProduct",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "280133a6-92f4-4378-beb6-fdd8dbfe9075", "AQAAAAEAACcQAAAAEF6w76cFxNKsBfym5VdvTXtGiXPhfrdnkCGTiSwTKEzzC8x/5U4qBJP5LeHwAZcC6Q==", "f2c86e7d-4f77-4c55-842f-c94c7e3e3e96" });

            migrationBuilder.DeleteData(
                 table: "AspNetUserRoles",
                 keyColumns: new[] { "RoleId", "UserId" },
                 keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }
    }
}
