using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.TemplateEntity
{
    public class Template : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public ICollection<Decree> Decrees { get; set; }
    }
}
