using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class AddTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var sqlFile = Path.Combine(solutionDir, @"MilitaryManager.Infrastructure\Migrations", "20221007141251_Triggers.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
