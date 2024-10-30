using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp_v3.Data.Migrations
{
    public partial class SeedingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "575a6734-fae6-4531-95df-510f4b7f954d", 0, "38865367-2477-4617-9faf-c4c616b5a88c", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEEh7i/tymU16jyDZJIBLoVyxDvl4chLeQjnEfEIjBVWr9j2DC9IIiPhjGtgSwHQMmQ==", null, false, "583b0283-afd0-423a-a98b-565b6e24263a", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 11, 18, 41, 47, 362, DateTimeKind.Local).AddTicks(3399), "Implement better styling for all public pages.", "575a6734-fae6-4531-95df-510f4b7f954d", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2024, 5, 28, 18, 41, 47, 362, DateTimeKind.Local).AddTicks(3472), "Create Android client application for the TaskBoard RESTful API.", "575a6734-fae6-4531-95df-510f4b7f954d", "Android Client Application" },
                    { 3, 2, new DateTime(2024, 9, 28, 18, 41, 47, 362, DateTimeKind.Local).AddTicks(3496), "Create Windows Forms desktop application client for the TaskBoard RESTful API.", "575a6734-fae6-4531-95df-510f4b7f954d", "Desktop Client Application" },
                    { 4, 3, new DateTime(2023, 10, 28, 18, 41, 47, 362, DateTimeKind.Local).AddTicks(3511), "Implement [Create Task] page for easier adding new tasks.", "575a6734-fae6-4531-95df-510f4b7f954d", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "575a6734-fae6-4531-95df-510f4b7f954d");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
