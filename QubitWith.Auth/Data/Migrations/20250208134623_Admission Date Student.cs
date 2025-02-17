using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QubitWith.Auth.Migrations
{
    /// <inheritdoc />
    public partial class AdmissionDateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "AcademicPeriods",
                newName: "AcademicYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicYear",
                table: "AcademicPeriods",
                newName: "Year");
        }
    }
}
