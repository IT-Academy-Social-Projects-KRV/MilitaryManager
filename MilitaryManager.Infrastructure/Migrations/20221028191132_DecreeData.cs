using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class DecreeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplatePlaceholders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePlaceholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplatePlaceholders_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecreeDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<object>(type: "sql_variant", nullable: false),
                    DecreeId = table.Column<int>(nullable: false),
                    TemplatePlaceholderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecreeDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecreeDatas_Decrees_DecreeId",
                        column: x => x.DecreeId,
                        principalTable: "Decrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecreeDatas_TemplatePlaceholders_TemplatePlaceholderId",
                        column: x => x.TemplatePlaceholderId,
                        principalTable: "TemplatePlaceholders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TemplatePlaceholders",
                columns: new[] { "Id", "Name", "TemplateId" },
                values: new object[,]
                {
                    { 23, "percent", 2 },
                    { 26, "father", 2 },
                    { 27, "commanderDivisionNumber", 3 },
                    { 28, "currentDate", 3 },
                    { 29, "city", 3 },
                    { 30, "decreeNumber", 3 },
                    { 31, "lastName", 3 },
                    { 32, "firstName", 3 },
                    { 33, "secondName", 3 },
                    { 34, "soldireDivisionNumber", 3 },
                    { 35, "assignmentDate", 3 },
                    { 36, "assignmentNumber", 3 },
                    { 37, "assignmentDivisionNumber", 3 },
                    { 38, "newDivisionNumber", 3 },
                    { 39, "dismissDate", 3 },
                    { 40, "divisionNumber", 3 },
                    { 41, "percent", 3 },
                    { 42, "increasePercent", 3 },
                    { 43, "serviceDateFrom", 3 },
                    { 44, "serviceDateTo", 3 },
                    { 45, "commanderRank", 3 },
                    { 46, "commanderLastName", 3 },
                    { 25, "first", 2 },
                    { 24, "anotherPercent", 2 },
                    { 48, "commanderSecondName", 3 },
                    { 22, "unitNumber", 2 },
                    { 1, "decreeNumber", 1 },
                    { 2, "currentDate", 1 },
                    { 3, "city", 1 },
                    { 4, "street", 1 },
                    { 5, "number", 1 },
                    { 6, "date", 1 },
                    { 7, "owner", 1 },
                    { 8, "flatnum", 1 },
                    { 9, "text", 1 },
                    { 47, "commanderFirstName", 3 },
                    { 10, "currentDate", 2 },
                    { 12, "decreeNumber", 2 },
                    { 13, "lastName", 2 },
                    { 14, "firstName", 2 },
                    { 15, "unitNumber", 2 },
                    { 16, "day", 2 },
                    { 17, "month", 2 },
                    { 18, "year", 2 },
                    { 19, "decreeNumber2", 2 },
                    { 20, "unitNumberNew", 2 },
                    { 21, "newPlace", 2 },
                    { 11, "city", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecreeDatas_DecreeId",
                table: "DecreeDatas",
                column: "DecreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecreeDatas_TemplatePlaceholderId",
                table: "DecreeDatas",
                column: "TemplatePlaceholderId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePlaceholders_TemplateId",
                table: "TemplatePlaceholders",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecreeDatas");

            migrationBuilder.DropTable(
                name: "TemplatePlaceholders");

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
