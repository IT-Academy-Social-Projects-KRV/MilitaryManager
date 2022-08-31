using System;
using System.Collections.Generic;

namespace MilitaryManager.Attachments.API.Entities
{
    public class Decree : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string PathSigned { get; set; }
        public string CreatedBy { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public IEnumerable<StatusHistory> StatusHistories { get; set; }
    }
}
