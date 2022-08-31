using System.Collections.Generic;

namespace MilitaryManager.Attachments.API.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Decree> Decrees { get; set; }
        public IEnumerable<StatusHistory> OldStatuses { get; set; }
        public IEnumerable<StatusHistory> NewStatuses { get; set; }
    }
}
