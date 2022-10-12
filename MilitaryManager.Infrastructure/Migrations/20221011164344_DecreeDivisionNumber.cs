using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class DecreeDivisionNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DivisionNumber",
                schema: "Unit",
                table: "Divisions",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecreeNumber",
                table: "Decrees",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DivisionNumber",
                schema: "Unit",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DecreeNumber",
                table: "Decrees");
        }
    }
}
