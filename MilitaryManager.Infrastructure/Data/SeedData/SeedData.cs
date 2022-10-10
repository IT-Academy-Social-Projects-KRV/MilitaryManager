using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Infrastructure.Data.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedDecreeStatuses(builder);
            SeedTemplates(builder);
            SeedChangeTypes(builder);
            SeedTables(builder);
            SeedColumns(builder);
        }

        public static void SeedDecreeStatuses(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status()
                {
                    Id = (int)DecreeStatus.CREATED,
                    Name = "Created"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.DOWNLOADED,
                    Name = "Downloaded"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.SIGNED,
                    Name = "Signed"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.COMPLETED,
                    Name = "Completed"
                });
        }

        public static void SeedTemplates(ModelBuilder builder)
        {
            builder.Entity<Template>().HasData(
                new Template()
                {
                    Id = 1,
                    Type = "Протокол",
                    Path = "data/document_templates/template_01.xml"
                }
                );
        }

        public static void SeedChangeTypes(ModelBuilder builder)
        {
            builder.Entity<ChangeType>().HasData(
                new ChangeType[]
                {
                    new ChangeType { Code = 'I', Name = "Insert"},
                    new ChangeType { Code = 'U', Name = "Update"},
                    new ChangeType { Code = 'D', Name = "Delete"}
                });
        }

        public static void SeedTables(ModelBuilder builder)
        {
            builder.Entity<Table>().HasData(
                new Table[]
                {
                    new Table { Name = "Attributes", Description = "Attributes for units and divisions"},
                    new Table { Name = "Divisions", Description = "Information about divisions"},
                    new Table { Name = "Entities", Description = "List of equipments"},
                    new Table { Name = "EntityToAttributes", Description = "Decoupling table for the connection between equipment and its attributes"},
                    new Table { Name = "Positions", Description = "List of unit positions"},
                    new Table { Name = "Profiles", Description = "Decoupling table for the connection between unit and its attributes"},
                    new Table { Name = "Ranks", Description = "List of unit ranks"},
                    new Table { Name = "Units", Description = "Information about unit"},
                    new Table { Name = "UnitToEquipments", Description = "Decoupling table for the connection between unit and its equipment"}
                });
        }

        public static void SeedColumns(ModelBuilder builder)
        {
            builder.Entity<Column>().HasData(
                new Column[]
                {
                    new Column { Name = "UnitParentId", TableName = "Units"},
                    new Column { Name = "DivisionsId", TableName = "Units"},
                    new Column { Name = "FirstName", TableName = "Units"},
                    new Column { Name = "LastName", TableName = "Units"},
                    new Column { Name = "PositionsId", TableName = "Units"},
                    new Column { Name = "RankId", TableName = "Units"},
                    new Column { Name = "Name", TableName = "Divisions"},
                    new Column { Name = "Address", TableName = "Divisions"},
                    new Column { Name = "DivisionParentId", TableName = "Divisions"}
                });
        }
    }
}
