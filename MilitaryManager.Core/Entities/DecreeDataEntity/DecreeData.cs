using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.TemplatePlaceholderEntity;
using MilitaryManager.Core.Interfaces;

namespace MilitaryManager.Core.Entities.DecreeDataEntity
{
    public class DecreeData : IBaseEntity<int>
    {
        public int Id { get; set; }
        public object Value { get; set; }
        public int DecreeId { get; set; }
        public Decree Decree { get; set; }
        public int TemplatePlaceholderId { get; set; }
        public TemplatePlaceholder TemplatePlaceholder { get; set; }
    }
}
