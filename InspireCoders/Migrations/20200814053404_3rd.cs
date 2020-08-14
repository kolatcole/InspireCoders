using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class _3rd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumID",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentIDs",
                table: "Forums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ForumID",
                table: "Students",
                column: "ForumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Forums_ForumID",
                table: "Students",
                column: "ForumID",
                principalTable: "Forums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Forums_ForumID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ForumID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ForumID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentIDs",
                table: "Forums");
        }
    }
}
