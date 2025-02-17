using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QubitWith.Auth.Migrations
{
    /// <inheritdoc />
    public partial class StudentAdmissionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "AdmissionDate",
                table: "Students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Students");
        }
    }
}
