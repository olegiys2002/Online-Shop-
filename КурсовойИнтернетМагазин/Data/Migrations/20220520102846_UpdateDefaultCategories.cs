using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace КурсовойИнтернетМагазин.Data.Migrations
{
    public partial class UpdateDefaultCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0fd8bba-06ef-4d06-8bd1-606f0df63f71", "AQAAAAEAACcQAAAAEL68C0RZm9eRyf0BCdX/xCKc0gWnrX6kdFHH0CV2XId49QP3ujgiDT88pY70AFDQ2A==", "45822c3c-d2f5-48b0-83f7-ad54013a4aa9" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Кондиционеры" },
                    { 5, "Тостеры" },
                    { 6, "Кофемашины" },
                    { 7, "Пылесосы" },
                    { 8, "Мультиварки" },
                    { 9, "Телевизоры" },
                    { 10, "Блендеры" },
                    { 11, "Мясорубки" },
                    { 12, "Соковыжималки" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bf50f5d-ec63-44d8-96da-18ba60fd0d51", "AQAAAAEAACcQAAAAEAonLhA3CDrymqJBoz4zsuiHdnbw3awdPVLDw6oLGXYHYhTutHRRpm3YQU7WeJzxVA==", "81b3a50f-932d-4548-8878-350cd723ae95" });
        }
    }
}
