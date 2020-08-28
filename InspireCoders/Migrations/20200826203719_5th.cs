using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4fd92e56-84aa-4ab0-9cca-3c3706aeef1e"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name", "Permissions" },
                values: new object[] { new Guid("8e4094af-20c7-4105-93f9-6c1b5d71684f"), new DateTime(2020, 8, 26, 21, 37, 18, 599, DateTimeKind.Local).AddTicks(8358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic Role", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8e4094af-20c7-4105-93f9-6c1b5d71684f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name", "Permissions" },
                values: new object[] { new Guid("4fd92e56-84aa-4ab0-9cca-3c3706aeef1e"), new DateTime(2020, 8, 26, 21, 26, 51, 995, DateTimeKind.Local).AddTicks(9995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic Role", "" });
        }
    }
}
