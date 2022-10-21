using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AttributeValueEntity;
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
            SeedRanks(builder);
            SeedPositions(builder);
            SeedAttributes(builder);
            SeedAttributeValues(builder);
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

        public static void SeedPositions(ModelBuilder builder)
        {
            builder.Entity<Position>().HasData(
                new Position[]
                {
                   new Position { Id = 1, Name = "Бойовий медик взводу" },
                   new Position { Id = 2, Name = "Вогнеметник" },
                   new Position { Id = 3, Name = "Водій" },
                   new Position { Id = 4, Name = "Головний сержант" },
                   new Position { Id = 5, Name = "Головний старшина" },
                   new Position { Id = 6, Name = "Гранатометник" },
                   new Position { Id = 7, Name = "Сапер розмінування" },
                   new Position { Id = 8, Name = "Командир відділення" },
                   new Position { Id = 9, Name = "Командир взводу" },
                   new Position { Id = 10, Name = "Командир гармати" },
                   new Position { Id = 11, Name = "Командир гранатомета" },
                   new Position { Id = 12, Name = "Командир зенітної ракетної самохідної установки" },
                   new Position { Id = 13, Name = "Командир міномета" },
                   new Position { Id = 14, Name = "Командир самохідної артилерійської установки" },
                   new Position { Id = 15, Name = "Командир танка" },
                   new Position { Id = 16, Name = "Командир установки" },
                   new Position { Id = 17, Name = "Кулеметник" },
                   new Position { Id = 18, Name = "Кухар" },
                   new Position { Id = 19, Name = "Льотчик-оператор " },
                   new Position { Id = 20, Name = "Льотчик-штурман " },
                   new Position { Id = 21, Name = "Машиніст" },
                   new Position { Id = 22, Name = "Медична сестра" },
                   new Position { Id = 23, Name = "Механік" },
                   new Position { Id = 24, Name = "Механік-водій" },
                   new Position { Id = 25, Name = "Мінер" },
                   new Position { Id = 26, Name = "Мінометник" },
                   new Position { Id = 27, Name = "Молодша медична сестра" },
                   new Position { Id = 28, Name = "Навідник-оператор" },
                   new Position { Id = 29, Name = "Начальник автомобільної колони" },
                   new Position { Id = 30, Name = "Начальник інформаційно-аналітичної групи" },
                   new Position { Id = 31, Name = "Начальник балістичної станції" },
                   new Position { Id = 32, Name = "Начальник відділення" },
                   new Position { Id = 33, Name = "Начальник групи" },
                   new Position { Id = 34, Name = "Начальник вузла зв'язку" },
                   new Position { Id = 35, Name = "Розвідник" },
                   new Position { Id = 36, Name = "Сапер" },
                   new Position { Id = 37, Name = "Стрілець-снайпер" },
                   new Position { Id = 38, Name = "Сержант резерву" },
                   new Position { Id = 39, Name = "Солдат резерву" },
                   new Position { Id = 40, Name = "Снайпер (1 категорії)" },
                   new Position { Id = 41, Name = "Снайпер (2 категорії)" },
                   new Position { Id = 42, Name = "Старшина команди" },
                   new Position { Id = 43, Name = "Стрілець" },
                   new Position { Id = 44, Name = "Стрілець-зенітник" },
                   new Position { Id = 45, Name = "Технік" },
                   new Position { Id = 46, Name = "Черговий" },
                });
        }

        public static void SeedRanks(ModelBuilder builder)
        {
            builder.Entity<Rank>().HasData(
                new Rank[]
                {
                    new Rank { Id = 1, Name = "Курсант" },
                    new Rank { Id = 2, Name = "Молодший лейтенант" },
                    new Rank { Id = 3, Name = "Лейтенант" },
                    new Rank { Id = 4, Name = "Старший лейтенант" },
                    new Rank { Id = 5, Name = "Капітан" },
                    new Rank { Id = 6, Name = "Майор" },
                    new Rank { Id = 7, Name = "Підполковник" },
                    new Rank { Id = 8, Name = "Полковник" },
                    new Rank { Id = 9, Name = "Бригадний генерал" },
                    new Rank { Id = 10, Name = "Генерал-майор" },
                    new Rank { Id = 11, Name = "Генерал-лейтенант" },
                    new Rank { Id = 12, Name = "Генерал" },
                    new Rank { Id = 13, Name = "Рекрут" },
                    new Rank { Id = 14, Name = "Солдат" },
                    new Rank { Id = 15, Name = "Старший солдат" },
                    new Rank { Id = 16, Name = "Молодший сержант" },
                    new Rank { Id = 17, Name = "Сержант" },
                    new Rank { Id = 18, Name = "Старший сержант" },
                    new Rank { Id = 19, Name = "Головний сержант" },
                    new Rank { Id = 20, Name = "Штаб-сержант" },
                    new Rank { Id = 21, Name = "Майстер-сержант" },
                    new Rank { Id = 22, Name = "Старший майстер-сержант" },
                    new Rank { Id = 23, Name = "Головний майстер-сержант" }
                });
        }

        public static void SeedAttributes(ModelBuilder builder)
        {
            builder.Entity<Core.Entities.AttributeEntity.Attribute>().HasData(
                new Core.Entities.AttributeEntity.Attribute[]
                {
                    new Core.Entities.AttributeEntity.Attribute { Id = 1, Name = "Розмір ноги"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 2, Name = "Розмір голови"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 3, Name = "Розмір протигазу"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 4, Name = "Тип форми"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 5, Name = "Група крові"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 6, Name = "Нагорода"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 7, Name = "Клас захисту"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 8, Name = "Назва"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 9, Name = "Виробник"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 10, Name = "Калібр"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 11, Name = "Вид стрілецької зброї"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 12, Name = "Тип калібру"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 13, Name = "Спосіб дії"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 14, Name = "Спосіб впливу"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 15, Name = "Тип прицілу"},
                    new Core.Entities.AttributeEntity.Attribute { Id = 16, Name = "Тип ПНБ"}
                });
        }

        public static void SeedAttributeValues(ModelBuilder builder)
        {
            builder.Entity<AttributeValue>().HasData(
                new AttributeValue[]
                {
                    new AttributeValue { Id = 1, AttributeId = 4, Value = "Стандар NATO"},
                    new AttributeValue { Id = 2, AttributeId = 4, Value = "Стандар України"},
                    new AttributeValue { Id = 3, AttributeId = 5, Value = "I+"},
                    new AttributeValue { Id = 4, AttributeId = 5, Value = "I-"},
                    new AttributeValue { Id = 5, AttributeId = 5, Value = "II+"},
                    new AttributeValue { Id = 6, AttributeId = 5, Value = "II-"},
                    new AttributeValue { Id = 7, AttributeId = 5, Value = "III+"},
                    new AttributeValue { Id = 8, AttributeId = 5, Value = "III-"},
                    new AttributeValue { Id = 9, AttributeId = 5, Value = "IV+"},
                    new AttributeValue { Id = 10, AttributeId = 5, Value = "IV-"},
                });
        }
    }
}
