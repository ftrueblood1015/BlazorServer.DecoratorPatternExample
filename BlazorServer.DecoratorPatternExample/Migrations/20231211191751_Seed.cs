using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.DecoratorPatternExample.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Anniversaries",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 1, "My Anniversay", new DateTime(2015, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Anniversay", true, "My Anniversay" });

            migrationBuilder.InsertData(
                table: "Anniversaries",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 2, "Not My Anniversay", new DateTime(2014, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not My Anniversay", true, "Not My Anniversay" });

            migrationBuilder.InsertData(
                table: "Birthdays",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 1, "My Bday", new DateTime(2000, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fletcher Bday", true, "Fletcher Bday" });

            migrationBuilder.InsertData(
                table: "Birthdays",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 2, "Not My Bday", new DateTime(1981, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not My Bday", true, "Not My Bday" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 1, "Its Christmas", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas", true, "Christmas" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Comments", "Date", "Description", "IsActive", "Name" },
                values: new object[] { 2, "Its New Years Eve", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Years Eve", true, "New Years Eve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Anniversaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Anniversaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Birthdays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Birthdays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
