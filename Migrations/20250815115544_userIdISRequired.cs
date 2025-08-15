using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace storeapi.Migrations
{
    /// <inheritdoc />
    public partial class userIdISRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "66c847fe-3226-47f2-bd62-26fe271f55ac");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d5f2825e-b040-4c0c-bd7f-7e97af732d19");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69d282e0-1ef3-463e-9fe9-18a7566e0d29", null, "Admin", "ADMIN" },
                    { "ca71216f-a6f7-41d8-b80b-5e65585a2c96", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "69d282e0-1ef3-463e-9fe9-18a7566e0d29");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ca71216f-a6f7-41d8-b80b-5e65585a2c96");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66c847fe-3226-47f2-bd62-26fe271f55ac", null, "User", "USER" },
                    { "d5f2825e-b040-4c0c-bd7f-7e97af732d19", null, "Admin", "ADMIN" }
                });
        }
    }
}
