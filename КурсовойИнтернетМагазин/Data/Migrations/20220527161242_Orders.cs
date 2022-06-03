using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace КурсовойИнтернетМагазин.Data.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ede19ef-ee65-4fff-a1f8-7ade34f4f0a0", "AQAAAAEAACcQAAAAEAabXhn5NuKlEawZyZNlRlWP2XpIxnFq4FmJIHEbjpSUeNIu7ymAB1aRm9WDci8D/g==", "8461ffe8-0c24-4312-b2c9-02196312ea3c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4588710-c93d-45a7-a2dd-6f10714b2647", "AQAAAAEAACcQAAAAECOuW1gJcweNyZmWZSNjMopr/NIkQwvKjJPpI5AYlyyjgYNknC100VFByYk4zcomvA==", "e97c2af4-b0ec-42ed-8c3b-95751edd5ee0" });

     
        }
    }
}
