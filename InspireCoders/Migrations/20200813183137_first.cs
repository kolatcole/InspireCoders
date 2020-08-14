using Microsoft.EntityFrameworkCore.Migrations;

namespace InspireCoders.Presentation.Core.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilitators_Courses_CourseID",
                table: "Facilitators");

            migrationBuilder.DropIndex(
                name: "IX_Facilitators_CourseID",
                table: "Facilitators");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Facilitators");

            migrationBuilder.AddColumn<string>(
                name: "FacilitatorIDs",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilitatorIDs",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Facilitators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facilitators_CourseID",
                table: "Facilitators",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilitators_Courses_CourseID",
                table: "Facilitators",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
