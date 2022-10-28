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
                    { 1, "decreeNumber", 1 },
                    { 21, "newPlace", 2 },
                    { 22, "unitNumber", 2 },
                    { 23, "percent", 2 },
                    { 24, "anotherPercent", 2 },
                    { 25, "first", 2 },
                    { 26, "father", 2 },
                    { 27, "currentDate", 3 },
                    { 28, "decreeNumber", 3 },
                    { 29, "lastName", 3 },
                    { 30, "firstName", 3 },
                    { 31, "secondName", 3 },
                    { 32, "divisionNumber", 3 },
                    { 33, "commanderDivision", 3 },
                    { 34, "commanderRank", 3 },
                    { 35, "commanderLastName", 3 },
                    { 20, "unitNumberNew", 2 },
                    { 36, "commanderFirstName", 3 },
                    { 19, "decreeNumber2", 2 },
                    { 17, "month", 2 },
                    { 2, "currentDate", 1 },
                    { 3, "city", 1 },
                    { 4, "street", 1 },
                    { 5, "number", 1 },
                    { 6, "date", 1 },
                    { 7, "owner", 1 },
                    { 8, "flatnum", 1 },
                    { 9, "text", 1 },
                    { 10, "currentDate", 2 },
                    { 11, "city", 2 },
                    { 12, "decreeNumber", 2 },
                    { 13, "lastName", 2 },
                    { 14, "firstName", 2 },
                    { 15, "unitNumber", 2 },
                    { 16, "day", 2 },
                    { 18, "year", 2 },
                    { 37, "commanderSecondName", 3 }
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
        }
    }
}
