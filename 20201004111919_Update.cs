using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioProject.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemoveUserUniversity",
                table: "UserUniversities");

            migrationBuilder.DropColumn(
                name: "RemoveUserTechnicalSkill",
                table: "UserTechnicalSkills");

            migrationBuilder.DropColumn(
                name: "RemoveUserInterpersonalSkill",
                table: "UserInterpersonalSkills");

            migrationBuilder.DropColumn(
                name: "RemoveProject",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RemoveUser",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AdminorUser",
                table: "AspNetUsers",
                defaultValue : "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminorUser",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "RemoveUserUniversity",
                table: "UserUniversities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoveUserTechnicalSkill",
                table: "UserTechnicalSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoveUserInterpersonalSkill",
                table: "UserInterpersonalSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoveProject",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoveUser",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
