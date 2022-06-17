using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f08fbe36-4976-4963-ace3-e3a09914a3b8", "AQAAAAEAACcQAAAAEDtzB3jz0tYxmVmt4FRBngFc38rl6ugBi7UENzV5pTIWsg/tZ/kdkvSqu+ZDjqoHOg==", "37631649-445d-400e-b39f-43f2a58bebcc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f00b131-8d04-4b4a-b9c4-d248697cd4a9", "AQAAAAEAACcQAAAAEJi44VI76vCNb/EkAtMRqTuF3OMioMi1M7hJYEX1QxgSLIymAIvKbziQIuAZvOmoZw==", "73299c53-4a3e-4ba1-b26a-c92b2b0dffb8" });
        }
    }
}
