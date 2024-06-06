using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_Product", "Name", "depth", "height", "weight", "width" },
                values: new object[,]
                {
                    { 1, "Laptop", 20.0, 2.0, 2.5, 30.0 },
                    { 2, "Smartphone", 15.0, 0.69999999999999996, 0.20000000000000001, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "Email", "FK_Role", "First_Name", "Last_Name", "Phone" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", 1, "John", "Doe", "123456789" },
                    { 2, "jane.smith@example.com", 2, "Jane", "Smith", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Products_Categories",
                columns: new[] { "FK_Category", "FK_Product" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "FK_Account", "FK_Product", "amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_Category", "FK_Product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_Category", "FK_Product" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumns: new[] { "FK_Account", "FK_Product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumns: new[] { "FK_Account", "FK_Product" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_Product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_Product",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 2);
        }
    }
}
