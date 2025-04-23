using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOs.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DOs",
                columns: new[] { "Id", "Done", "DueDate", "Title" },
                values: new object[] { "1", false, new DateTime(2025, 4, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Moni" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DOs",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
