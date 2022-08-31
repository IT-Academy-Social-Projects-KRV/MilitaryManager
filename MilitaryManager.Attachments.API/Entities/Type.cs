using System.Collections.Generic;

namespace MilitaryManager.Attachments.API.Entities
{
    public class Type : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Decree> Decrees { get; set; }
    }
}
