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
    }
}
