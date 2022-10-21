using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.RankEntity;
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
                },
                new Template()
                {
                    Id = 2,
                    Type = "Виплата",
                    Path = "data/document_templates/template_02.xml"
                },
                new Template()
                {
                    Id = 3,
                    Type = "Переведення",
                    Path = "data/document_templates/template_03.xml"
                });
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
                    new Column { Name = "DivisionId", TableName = "Units"},
                    new Column { Name = "FirstName", TableName = "Units"},
                    new Column { Name = "LastName", TableName = "Units"},
                    new Column { Name = "PositionId", TableName = "Units"},
                    new Column { Name = "RankId", TableName = "Units"},
                    new Column { Name = "Name", TableName = "Divisions"},
                    new Column { Name = "Address", TableName = "Divisions"},
                    new Column { Name = "DivisionParentId", TableName = "Divisions"}
                });
        }

        public static void SeedRanks(ModelBuilder builder)
        {
            builder.Entity<Rank>().HasData(
                new Rank[]
                {
                    new Rank { Name = "Курсант" },
                    new Rank { Name = "Молодший лейтенант" },
                    new Rank { Name = "Лейтенант" },
                    new Rank { Name = "Старший лейтенант" },
                    new Rank { Name = "Капітан" },
                    new Rank { Name = "Майор" },
                    new Rank { Name = "Підполковник" },
                    new Rank { Name = "Полковник" },
                    new Rank { Name = "Бригадний генерал" },
                    new Rank { Name = "Генерал-майор" },
                    new Rank { Name = "Генерал-лейтенант" },
                    new Rank { Name = "Генерал" },
                    new Rank { Name = "Рекрут" },
                    new Rank { Name = "Солдат" },
                    new Rank { Name = "Старший солдат" },
                    new Rank { Name = "Молодший сержант" },
                    new Rank { Name = "Сержант" },
                    new Rank { Name = "Старший сержант" },
                    new Rank { Name = "Головний сержант" },
                    new Rank { Name = "Штаб-сержант" },
                    new Rank { Name = "Майстер-сержант" },
                    new Rank { Name = "Старший майстер-сержант" },
                    new Rank { Name = "Головний майстер-сержант" }
                });
        }

        public static void SeedAttributes(ModelBuilder builder)
        {
            builder.Entity<Core.Entities.AttributeEntity.Attribute>().HasData(
                new Core.Entities.AttributeEntity.Attribute[]
                {
                    new Core.Entities.AttributeEntity.Attribute { Name = "Розмір ноги"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Розмір голови"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Розмір протигазу"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Тип форми"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Група крові"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Нагорода"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Клас захисту"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Назва"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Виробник"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Калібр"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Вид стрілецької зброї"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Тип калібру"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Спосіб дії"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Спосіб впливу"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Тип прицілу"},
                    new Core.Entities.AttributeEntity.Attribute { Name = "Тип ПНБ"}
                });
        }
    }
}
