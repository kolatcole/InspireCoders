using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class UMAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Permissions = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    PasswordSalt = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 512, nullable: false),
                    LastName = table.Column<string>(maxLength: 512, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    EmailVerified = table.Column<bool>(nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneVerified = table.Column<bool>(nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Sex = table.Column<string>(maxLength: 20, nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    ProfileImageURL = table.Column<string>(maxLength: 255, nullable: true),
                    RegistrationIP = table.Column<string>(maxLength: 50, nullable: true),
                    LastSeen = table.Column<DateTimeOffset>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Language = table.Column<string>(maxLength: 30, nullable: true),
                    RoleId = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
