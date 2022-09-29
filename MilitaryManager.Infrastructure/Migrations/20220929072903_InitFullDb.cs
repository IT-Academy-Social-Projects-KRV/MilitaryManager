using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class InitFullDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Units");

            migrationBuilder.EnsureSchema(
                name: "Unit");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Units",
                newSchema: "Unit");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                schema: "Unit",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Unit",
                table: "Units",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Unit",
                table: "Units",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                schema: "Unit",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                schema: "Unit",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Divisions_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Unit",
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Unit",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityToAttributes",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityToAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityToAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Unit",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityToAttributes_Entities_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Unit",
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToSoldiers",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true),
                    GivenById = table.Column<int>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    GivenDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentToSoldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "Unit",
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Units_GivenById",
                        column: x => x.GivenById,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Entities_Id",
                        column: x => x.Id,
                        principalSchema: "Unit",
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_DivisionId",
                schema: "Unit",
                table: "Units",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_PositionId",
                schema: "Unit",
                table: "Units",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_RankId",
                schema: "Unit",
                table: "Units",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentId",
                schema: "Unit",
                table: "Divisions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityToAttributes_AttributeId",
                schema: "Unit",
                table: "EntityToAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityToAttributes_EntityId",
                schema: "Unit",
                table: "EntityToAttributes",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldiers_DivisionId",
                schema: "Unit",
                table: "EquipmentToSoldiers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldiers_GivenById",
                schema: "Unit",
                table: "EquipmentToSoldiers",
                column: "GivenById");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldiers_UnitId",
                schema: "Unit",
                table: "EquipmentToSoldiers",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AttributeId",
                schema: "Unit",
                table: "Profiles",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UnitId",
                schema: "Unit",
                table: "Profiles",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Divisions_DivisionId",
                schema: "Unit",
                table: "Units",
                column: "DivisionId",
                principalSchema: "Unit",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Positions_PositionId",
                schema: "Unit",
                table: "Units",
                column: "PositionId",
                principalSchema: "Unit",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Ranks_RankId",
                schema: "Unit",
                table: "Units",
                column: "RankId",
                principalSchema: "Unit",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Divisions_DivisionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Positions_PositionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Ranks_RankId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropTable(
                name: "EntityToAttributes",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "EquipmentToSoldiers",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Ranks",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Divisions",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Entities",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Units_DivisionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_PositionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_RankId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RankId",
                schema: "Unit",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                schema: "Unit",
                newName: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
