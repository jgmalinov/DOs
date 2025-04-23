using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOs.Migrations
{
    /// <inheritdoc />
    public partial class Updateschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DOs",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DOs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DOs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "DOs",
                columns: new[] { "Id", "Description", "Done", "DueDate", "Title" },
                values: new object[] { 1, "Know yourselves", false, new DateTime(2025, 4, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Moni" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DOs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DOs");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "DOs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "DOs",
                columns: new[] { "Id", "Done", "DueDate", "Title" },
                values: new object[] { "1", false, new DateTime(2025, 4, 25, 23, 59, 59, 0, DateTimeKind.Unspecified), "Moni" });
        }
    }
}
