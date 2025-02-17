using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QubitWith.Auth.Migrations
{
    /// <inheritdoc />
    public partial class Addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "135dff72-4c3e-4cc9-8b11-add93e6316dd", null, "SuperAdmin", "SUPERADMIN" },
                    { "238a5e67-d3c6-4980-a821-99a733012e02", null, "Student", "STUDENT" },
                    { "d51e518d-e7b7-4f39-ada0-cc9167cd5830", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "135dff72-4c3e-4cc9-8b11-add93e6316dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "238a5e67-d3c6-4980-a821-99a733012e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d51e518d-e7b7-4f39-ada0-cc9167cd5830");
        }
    }
}
