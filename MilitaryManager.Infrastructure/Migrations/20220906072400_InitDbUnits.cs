using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class InitDbUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Unit");

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
                name: "Units",
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
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Units_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Soldiers",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    UnitId = table.Column<int>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldiers_Soldiers_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Unit",
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Unit",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Soldiers_Ranks_RankId",
                        column: x => x.RankId,
                        principalSchema: "Unit",
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Soldiers_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToSoldiers",
                schema: "Unit",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false),
                    SoldierId = table.Column<int>(nullable: true),
                    GivenById = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    GivenDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentToSoldiers", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Entities_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Unit",
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Soldiers_GivenById",
                        column: x => x.GivenById,
                        principalSchema: "Unit",
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalSchema: "Unit",
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldiers_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    SoldierId = table.Column<int>(nullable: false),
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
                        name: "FK_Profiles_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalSchema: "Unit",
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_EquipmentToSoldiers_GivenById",
                schema: "Unit",
                table: "EquipmentToSoldiers",
                column: "GivenById");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldiers_SoldierId",
                schema: "Unit",
                table: "EquipmentToSoldiers",
                column: "SoldierId");

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
                name: "IX_Profiles_SoldierId",
                schema: "Unit",
                table: "Profiles",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_ParentId",
                schema: "Unit",
                table: "Soldiers",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_PositionId",
                schema: "Unit",
                table: "Soldiers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_RankId",
                schema: "Unit",
                table: "Soldiers",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_UnitId",
                schema: "Unit",
                table: "Soldiers",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentId",
                schema: "Unit",
                table: "Units",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityToAttributes",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "EquipmentToSoldiers",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Entities",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Soldiers",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Ranks",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "Unit");
        }
    }
}
