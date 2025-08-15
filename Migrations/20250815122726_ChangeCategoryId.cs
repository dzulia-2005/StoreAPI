using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace storeapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "21053383-dd90-4a0b-9d53-e1dd937fb5dd");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "491163d6-e8d3-43a2-8fe9-c3e2f2013025");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "096c8c72-4a9e-4efa-86ff-23b15373dc50", null, "Admin", "ADMIN" },
                    { "8220591f-8572-456f-a70c-b943da5d0fb9", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "096c8c72-4a9e-4efa-86ff-23b15373dc50");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8220591f-8572-456f-a70c-b943da5d0fb9");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21053383-dd90-4a0b-9d53-e1dd937fb5dd", null, "Admin", "ADMIN" },
                    { "491163d6-e8d3-43a2-8fe9-c3e2f2013025", null, "User", "USER" }
                });
        }
    }
}
