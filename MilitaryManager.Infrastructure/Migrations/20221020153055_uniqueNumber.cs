using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class uniqueNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Path", "Type" },
                values: new object[] { 2, "data/document_templates/template_02.xml", "Виплата" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Path", "Type" },
                values: new object[] { 3, "data/document_templates/template_03.xml", "Переведення" });
        }
    }
}
