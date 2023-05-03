using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_ASP.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03ff7f81-f106-4900-bcd6-6b56baa8da40", "12304703-e569-41f8-9ee7-f2b0bc7b1f77", "admin", "ADMIN" },
                    { "e0881564-bd29-46ce-bde7-42de07e5268b", "7f13e532-8f3e-4542-ae45-7b0daf4faa6f", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ff7f81-f106-4900-bcd6-6b56baa8da40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0881564-bd29-46ce-bde7-42de07e5268b");
        }
    }
}
