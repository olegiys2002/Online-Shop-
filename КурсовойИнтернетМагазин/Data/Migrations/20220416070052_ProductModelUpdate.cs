using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Data.Migrations
{
    public partial class ProductModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "customer", "customer" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "280133a6-92f4-4378-beb6-fdd8dbfe9075", "AQAAAAEAACcQAAAAEF6w76cFxNKsBfym5VdvTXtGiXPhfrdnkCGTiSwTKEzzC8x/5U4qBJP5LeHwAZcC6Q==", "f2c86e7d-4f77-4c55-842f-c94c7e3e3e96" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Model");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Customer", "Customer" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f08fbe36-4976-4963-ace3-e3a09914a3b8", "AQAAAAEAACcQAAAAEDtzB3jz0tYxmVmt4FRBngFc38rl6ugBi7UENzV5pTIWsg/tZ/kdkvSqu+ZDjqoHOg==", "37631649-445d-400e-b39f-43f2a58bebcc" });
        }
    }
}
