using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class _6th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8e4094af-20c7-4105-93f9-6c1b5d71684f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name", "Permissions" },
                values: new object[] { new Guid("fbdfd627-af64-421e-ac1d-fc9384305a51"), new DateTime(2020, 8, 26, 22, 27, 19, 907, DateTimeKind.Local).AddTicks(2942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic Role", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fbdfd627-af64-421e-ac1d-fc9384305a51"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name", "Permissions" },
                values: new object[] { new Guid("8e4094af-20c7-4105-93f9-6c1b5d71684f"), new DateTime(2020, 8, 26, 21, 37, 18, 599, DateTimeKind.Local).AddTicks(8358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic Role", "" });
        }
    }
}
