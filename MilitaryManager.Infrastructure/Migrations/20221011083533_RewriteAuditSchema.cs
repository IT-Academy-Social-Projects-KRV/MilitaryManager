using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class RewriteAuditSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeValue",
                schema: "audit",
                table: "ChangeValue");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "audit",
                table: "ChangeValue",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeValue",
                schema: "audit",
                table: "ChangeValue",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeValue_ChangeId",
                schema: "audit",
                table: "ChangeValue",
                column: "ChangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeValue",
                schema: "audit",
                table: "ChangeValue");

            migrationBuilder.DropIndex(
                name: "IX_ChangeValue_ChangeId",
                schema: "audit",
                table: "ChangeValue");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "audit",
                table: "ChangeValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeValue",
                schema: "audit",
                table: "ChangeValue",
                column: "ChangeId");
        }
    }
}
