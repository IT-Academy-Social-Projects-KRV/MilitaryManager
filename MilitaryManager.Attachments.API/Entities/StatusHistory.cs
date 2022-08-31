using System;

namespace MilitaryManager.Attachments.API.Entities
{
    public class StatusHistory : BaseEntity
    {
        public string PerformedBy { get; set; }
        public DateTime TimeStamp { get; set; }
        public int DecreeId { get; set; }
        public Decree Decree { get; set; }
        public int OldStatusId { get; set; }
        public Status OldStatus { get; set; }
        public int NewStatusId { get; set; }
        public Status NewStatus { get; set; }
    }
}
