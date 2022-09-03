using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class InitSchemaUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Unit");

            migrationBuilder.CreateTable(
                name: "Attribute",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
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
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Unit_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Unit",
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityToAttribute",
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
                    table.PrimaryKey("PK_EntityToAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityToAttribute_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Unit",
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityToAttribute_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Unit",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soldier",
                schema: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    UnitId = table.Column<int>(nullable: true),
                    RankId = table.Column<int>(nullable: true),
                    PatronymicId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldier_Soldier_PatronymicId",
                        column: x => x.PatronymicId,
                        principalSchema: "Unit",
                        principalTable: "Soldier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldier_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Unit",
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldier_Rank_RankId",
                        column: x => x.RankId,
                        principalSchema: "Unit",
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldier_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToSoldier",
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
                    table.PrimaryKey("PK_EquipmentToSoldier", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldier_Entity_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Unit",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldier_Soldier_GivenById",
                        column: x => x.GivenById,
                        principalSchema: "Unit",
                        principalTable: "Soldier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldier_Soldier_SoldierId",
                        column: x => x.SoldierId,
                        principalSchema: "Unit",
                        principalTable: "Soldier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToSoldier_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Unit",
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
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
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Unit",
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Soldier_SoldierId",
                        column: x => x.SoldierId,
                        principalSchema: "Unit",
                        principalTable: "Soldier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 1, "Address1", "Charles Montgomery Burns", null });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 2, "Address1", "Waylon Smithers, Jr.", 1 });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 3, "Address1", "Lenny Leonard", 2 });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 4, "Address1", "Carl Carlson", 2 });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 5, "Address1", "Inanimate Carbon Rod", 4 });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Unit",
                columns: new[] { "Id", "Address", "Name", "ParentId" },
                values: new object[] { 6, "Address1", "Homer Simpson", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_EntityToAttribute_AttributeId",
                schema: "Unit",
                table: "EntityToAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityToAttribute_EntityId",
                schema: "Unit",
                table: "EntityToAttribute",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldier_GivenById",
                schema: "Unit",
                table: "EquipmentToSoldier",
                column: "GivenById");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldier_SoldierId",
                schema: "Unit",
                table: "EquipmentToSoldier",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToSoldier_UnitId",
                schema: "Unit",
                table: "EquipmentToSoldier",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AttributeId",
                schema: "Unit",
                table: "Profile",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_SoldierId",
                schema: "Unit",
                table: "Profile",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_PatronymicId",
                schema: "Unit",
                table: "Soldier",
                column: "PatronymicId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_PositionId",
                schema: "Unit",
                table: "Soldier",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_RankId",
                schema: "Unit",
                table: "Soldier",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_UnitId",
                schema: "Unit",
                table: "Soldier",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ParentId",
                schema: "Unit",
                table: "Unit",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityToAttribute",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "EquipmentToSoldier",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Attribute",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Soldier",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Rank",
                schema: "Unit");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "Unit");
        }
    }
}
