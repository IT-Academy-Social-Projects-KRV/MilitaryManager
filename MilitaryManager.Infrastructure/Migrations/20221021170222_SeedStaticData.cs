using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryManager.Infrastructure.Migrations
{
    public partial class SeedStaticData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Attributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Розмір ноги" },
                    { 16, "Тип ПНБ" },
                    { 15, "Тип прицілу" },
                    { 14, "Спосіб впливу" },
                    { 12, "Тип калібру" },
                    { 11, "Вид стрілецької зброї" },
                    { 10, "Калібр" },
                    { 9, "Виробник" },
                    { 13, "Спосіб дії" },
                    { 7, "Клас захисту" },
                    { 6, "Нагорода" },
                    { 5, "Група крові" },
                    { 4, "Тип форми" },
                    { 3, "Розмір протигазу" },
                    { 2, "Розмір голови" },
                    { 8, "Назва" }
                });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 34, "Начальник вузла зв'язку" },
                    { 33, "Начальник групи" },
                    { 32, "Начальник відділення" },
                    { 31, "Начальник балістичної станції" },
                    { 28, "Навідник-оператор" },
                    { 29, "Начальник автомобільної колони" },
                    { 26, "Мінометник" },
                    { 35, "Розвідник" },
                    { 30, "Начальник інформаційно-аналітичної групи" },
                    { 36, "Сапер" },
                    { 44, "Стрілець-зенітник" },
                    { 38, "Сержант резерву" },
                    { 39, "Солдат резерву" },
                    { 40, "Снайпер (1 категорії)" },
                    { 41, "Снайпер (2 категорії)" },
                    { 42, "Старшина команди" },
                    { 43, "Стрілець" },
                    { 25, "Мінер" },
                    { 45, "Технік" },
                    { 46, "Черговий" },
                    { 37, "Стрілець-снайпер" },
                    { 24, "Механік-водій" },
                    { 27, "Молодша медична сестра" },
                    { 22, "Медична сестра" },
                    { 23, "Механік" },
                    { 2, "Вогнеметник" },
                    { 3, "Водій" },
                    { 4, "Головний сержант" },
                    { 5, "Головний старшина" },
                    { 6, "Гранатометник" },
                    { 7, "Сапер розмінування" },
                    { 8, "Командир відділення" },
                    { 9, "Командир взводу" },
                    { 10, "Командир гармати" },
                    { 11, "Командир гранатомета" },
                    { 1, "Бойовий медик взводу" },
                    { 13, "Командир міномета" },
                    { 12, "Командир зенітної ракетної самохідної установки" },
                    { 20, "Льотчик-штурман " },
                    { 19, "Льотчик-оператор " },
                    { 18, "Кухар" },
                    { 21, "Машиніст" },
                    { 16, "Командир установки" },
                    { 15, "Командир танка" },
                    { 14, "Командир самохідної артилерійської установки" },
                    { 17, "Кулеметник" }
                });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "Ranks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 21, "Майстер-сержант" },
                    { 13, "Рекрут" },
                    { 20, "Штаб-сержант" },
                    { 19, "Головний сержант" },
                    { 18, "Старший сержант" },
                    { 17, "Сержант" },
                    { 16, "Молодший сержант" },
                    { 15, "Старший солдат" },
                    { 14, "Солдат" },
                    { 12, "Генерал" },
                    { 7, "Підполковник" },
                    { 10, "Генерал-майор" },
                    { 9, "Бригадний генерал" },
                    { 8, "Полковник" },
                    { 6, "Майор" },
                    { 5, "Капітан" },
                    { 4, "Старший лейтенант" },
                    { 3, "Лейтенант" },
                    { 2, "Молодший лейтенант" },
                    { 1, "Курсант" },
                    { 22, "Старший майстер-сержант" },
                    { 11, "Генерал-лейтенант" },
                    { 23, "Головний майстер-сержант" }
                });

            migrationBuilder.InsertData(
                schema: "Unit",
                table: "AttributeValues",
                columns: new[] { "Id", "AttributeId", "Value" },
                values: new object[,]
                {
                    { 1, 4, "Стандарт NATO" },
                    { 2, 4, "Стандарт України" },
                    { 3, 5, "I+" },
                    { 4, 5, "I-" },
                    { 5, 5, "II+" },
                    { 6, 5, "II-" },
                    { 7, 5, "III+" },
                    { 8, 5, "III-" },
                    { 9, 5, "IV+" },
                    { 10, 5, "IV-" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Unit",
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
