using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioProject.Data.Migrations
{
    public partial class port : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
