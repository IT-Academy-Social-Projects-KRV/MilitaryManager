using MilitaryManager.Core.Entities.DecreeDataEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.TemplatePlaceholderEntity
{
    public class TemplatePlaceholder : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public ICollection<DecreeData> DecreeDatas { get; set; }


        public List<TemplatePlaceholder> GetTemplatePlaceholders()
        {
            List<TemplatePlaceholder> placeholders = new List<TemplatePlaceholder>()
            {
                new TemplatePlaceholder() { Id = 1, Name = "decreeNumber", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 2, Name = "currentDate", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 3, Name = "city", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 4, Name = "street", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 5, Name = "number", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 6, Name = "date", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 7, Name = "owner", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 8, Name = "flatnum", TemplateId = 1 },
                new TemplatePlaceholder() { Id = 9, Name = "text", TemplateId = 1 },

                new TemplatePlaceholder() { Id = 10, Name = "currentDate", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 11, Name = "city", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 12, Name = "decreeNumber", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 13, Name = "lastName", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 14, Name = "firstName", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 15, Name = "unitNumber", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 16, Name = "day", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 17, Name = "month", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 18, Name = "year", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 19, Name = "decreeNumber2", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 20, Name = "unitNumberNew", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 21, Name = "newPlace", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 22, Name = "unitNumber", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 23, Name = "percent", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 24, Name = "anotherPercent", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 25, Name = "first", TemplateId = 2 },
                new TemplatePlaceholder() { Id = 26, Name = "father", TemplateId = 2 },

                new TemplatePlaceholder() { Id = 27, Name = "commanderDivisionNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 28, Name = "currentDate", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 29, Name = "city", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 30, Name = "decreeNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 31, Name = "lastName", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 32, Name = "firstName", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 33, Name = "secondName", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 34, Name = "soldireDivisionNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 35, Name = "assignmentDate", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 36, Name = "assignmentNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 37, Name = "assignmentDivisionNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 38, Name = "newDivisionNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 39, Name = "dismissDate", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 40, Name = "divisionNumber", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 41, Name = "percent", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 42, Name = "increasePercent", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 43, Name = "serviceDateFrom", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 44, Name = "serviceDateTo", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 45, Name = "commanderRank", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 46, Name = "commanderLastName", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 47, Name = "commanderFirstName", TemplateId = 3 },
                new TemplatePlaceholder() { Id = 48 , Name = "commanderSecondName", TemplateId = 3 },
            };

            return placeholders;
        }
    }
}
