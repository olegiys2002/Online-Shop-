using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Data.Migrations
{
    public partial class AdminUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312179e3-a0b2-4159-bf4c-f46d95b5731e", "Admin", "AQAAAAEAACcQAAAAEHwbSLgu9fWqws3viFbN7BhyDPPrqh8FtQ0ex8nLmNkBCSBrirOrZjGHreQXGoDINg==", "824e4a4d-6972-4daa-8b37-53beeaaf4039" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b407441d-2ef6-4af7-8f1a-ce4e93ab979d", null, "AQAAAAEAACcQAAAAEIkGm32KxoNBxj8J+Ks8KK7L3a0E1OepSBBYGMWgUtNu+mSed0FJYj3lvdKNXS3GfQ==", "54a4d7d9-746d-4af3-9e08-85a966a0c5be" });
        }
    }
}
