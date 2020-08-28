using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class ist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name", "Permissions" },
                values: new object[] { new Guid("4fd92e56-84aa-4ab0-9cca-3c3706aeef1e"), new DateTime(2020, 8, 26, 21, 26, 51, 995, DateTimeKind.Local).AddTicks(9995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic Role", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4fd92e56-84aa-4ab0-9cca-3c3706aeef1e"));
        }
    }
}
