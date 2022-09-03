using System.Collections.Generic;

namespace MilitaryManager.Attachments.API.Entities
{
    public class Template : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public IEnumerable<Decree> Decrees { get; set; }
    }
}
