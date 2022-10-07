using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class AddStaticData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "audit",
                table: "ChangeType",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "I", "Insert" },
                    { "U", "Update" },
                    { "D", "Delete" }
                });

            migrationBuilder.InsertData(
                schema: "audit",
                table: "Table",
                columns: new[] { "Name", "Description" },
                values: new object[,]
                {
                    { "Attributes", "Attributes for units and divisions" },
                    { "Divisions", "Information about divisions" },
                    { "Entities", "List of equipments" },
                    { "EntityToAttributes", "Decoupling table for the connection between equipment and its attributes" },
                    { "Positions", "List of unit positions" },
                    { "Profiles", "Decoupling table for the connection between unit and its attributes" },
                    { "Ranks", "List of unit ranks" },
                    { "Units", "Information about unit" },
                    { "UnitToEquipments", "Decoupling table for the connection between unit and its equipment" }
                });

            migrationBuilder.InsertData(
                schema: "audit",
                table: "Column",
                columns: new[] { "Name", "TableName" },
                values: new object[,]
                {
                    { "Name", "Divisions" },
                    { "Address", "Divisions" },
                    { "DivisionParentId", "Divisions" },
                    { "UnitParentId", "Units" },
                    { "DivisionsId", "Units" },
                    { "FirstName", "Units" },
                    { "LastName", "Units" },
                    { "PositionsId", "Units" },
                    { "RankId", "Units" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "audit",
                table: "ChangeType",
                keyColumn: "Code",
                keyValue: "D");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "ChangeType",
                keyColumn: "Code",
                keyValue: "I");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "ChangeType",
                keyColumn: "Code",
                keyValue: "U");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "Address");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "DivisionParentId");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "DivisionsId");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "FirstName");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "LastName");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "Name");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "PositionsId");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "RankId");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Column",
                keyColumn: "Name",
                keyValue: "UnitParentId");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Attributes");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Entities");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "EntityToAttributes");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Positions");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Profiles");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Ranks");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "UnitToEquipments");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Divisions");

            migrationBuilder.DeleteData(
                schema: "audit",
                table: "Table",
                keyColumn: "Name",
                keyValue: "Units");
        }
    }
}
