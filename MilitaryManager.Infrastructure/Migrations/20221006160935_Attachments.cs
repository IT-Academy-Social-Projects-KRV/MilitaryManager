using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class Attachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Decrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Path = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 450, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decrees_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decrees_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignedPdfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignedPdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignedPdfs_Decrees_Id",
                        column: x => x.Id,
                        principalTable: "Decrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformedBy = table.Column<string>(maxLength: 450, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecreeId = table.Column<int>(nullable: false),
                    OldStatusId = table.Column<int>(nullable: false),
                    NewStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusHistories_Decrees_DecreeId",
                        column: x => x.DecreeId,
                        principalTable: "Decrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusHistories_Statuses_NewStatusId",
                        column: x => x.NewStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusHistories_Statuses_OldStatusId",
                        column: x => x.OldStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Downloaded" },
                    { 3, "Signed" },
                    { 4, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Path", "Type" },
                values: new object[] { 1, "data/document_templates/template_01.xml", "Протокол" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Path", "Type" },
                values: new object[] { 2, "data/document_templates/template_02.xml", "Виплата" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Path", "Type" },
                values: new object[] { 3, "data/document_templates/template_03.xml", "Переведення" });

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_StatusId",
                table: "Decrees",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_TemplateId",
                table: "Decrees",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_DecreeId",
                table: "StatusHistories",
                column: "DecreeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_NewStatusId",
                table: "StatusHistories",
                column: "NewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_OldStatusId",
                table: "StatusHistories",
                column: "OldStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignedPdfs");

            migrationBuilder.DropTable(
                name: "StatusHistories");

            migrationBuilder.DropTable(
                name: "Decrees");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
