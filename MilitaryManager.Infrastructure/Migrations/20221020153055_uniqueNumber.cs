using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class uniqueNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Decrees_DecreeNumber",
                table: "Decrees",
                column: "DecreeNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Decrees_DecreeNumber",
                table: "Decrees");
        }
    }
}
