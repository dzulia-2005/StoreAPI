using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace storeapi.Migrations
{
    /// <inheritdoc />
    public partial class NewMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f018a42c-2c54-4497-b043-a5163598874c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f0967b38-ade6-4d86-8010-716b3712b92e");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "602bf539-1108-41b4-a05e-52a93704ae10", null, "User", "USER" },
                    { "fc144339-b2ee-4c28-b89a-03ba0ab72da1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "602bf539-1108-41b4-a05e-52a93704ae10");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "fc144339-b2ee-4c28-b89a-03ba0ab72da1");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f018a42c-2c54-4497-b043-a5163598874c", null, "User", "USER" },
                    { "f0967b38-ade6-4d86-8010-716b3712b92e", null, "Admin", "ADMIN" }
                });
        }
    }
}
