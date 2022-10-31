using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class change_unit_to_equipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitToEquipments_Units_GivenById",
                schema: "Unit",
                table: "UnitToEquipments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GivenDate",
                schema: "Unit",
                table: "UnitToEquipments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "GivenById",
                schema: "Unit",
                table: "UnitToEquipments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitToEquipments_Units_GivenById",
                schema: "Unit",
                table: "UnitToEquipments",
                column: "GivenById",
                principalSchema: "Unit",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitToEquipments_Units_GivenById",
                schema: "Unit",
                table: "UnitToEquipments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GivenDate",
                schema: "Unit",
                table: "UnitToEquipments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GivenById",
                schema: "Unit",
                table: "UnitToEquipments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitToEquipments_Units_GivenById",
                schema: "Unit",
                table: "UnitToEquipments",
                column: "GivenById",
                principalSchema: "Unit",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
