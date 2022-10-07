using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class CreateAuditSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.CreateTable(
                name: "ChangeType",
                schema: "audit",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                schema: "audit",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Change",
                schema: "audit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    TableName = table.Column<string>(nullable: false),
                    RowId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ChangeTypeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Change", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Change_ChangeType_ChangeTypeCode",
                        column: x => x.ChangeTypeCode,
                        principalSchema: "audit",
                        principalTable: "ChangeType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Change_Table_TableName",
                        column: x => x.TableName,
                        principalSchema: "audit",
                        principalTable: "Table",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                schema: "audit",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    TableName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.Name);
                    table.UniqueConstraint("AK_Column_Name_TableName", x => new { x.Name, x.TableName });
                    table.ForeignKey(
                        name: "FK_Column_Table_TableName",
                        column: x => x.TableName,
                        principalSchema: "audit",
                        principalTable: "Table",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeValue",
                schema: "audit",
                columns: table => new
                {
                    ChangeId = table.Column<int>(nullable: false),
                    OldValue = table.Column<object>(type: "sql_variant", nullable: true),
                    NewValue = table.Column<object>(type: "sql_variant", nullable: true),
                    ColumnName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeValue", x => x.ChangeId);
                    table.ForeignKey(
                        name: "FK_ChangeValue_Change_ChangeId",
                        column: x => x.ChangeId,
                        principalSchema: "audit",
                        principalTable: "Change",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeValue_Column_ColumnName",
                        column: x => x.ColumnName,
                        principalSchema: "audit",
                        principalTable: "Column",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Change_ChangeTypeCode",
                schema: "audit",
                table: "Change",
                column: "ChangeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Change_TableName",
                schema: "audit",
                table: "Change",
                column: "TableName");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeValue_ColumnName",
                schema: "audit",
                table: "ChangeValue",
                column: "ColumnName");

            migrationBuilder.CreateIndex(
                name: "IX_Column_TableName",
                schema: "audit",
                table: "Column",
                column: "TableName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeValue",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "Change",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "Column",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "ChangeType",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "Table",
                schema: "audit");
        }
    }
}
