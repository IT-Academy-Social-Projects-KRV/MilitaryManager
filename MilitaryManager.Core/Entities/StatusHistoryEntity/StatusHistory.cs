using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Interfaces;
using System;

namespace MilitaryManager.Core.Entities.StatusHistoryEntity
{
    public class StatusHistory : IBaseEntity<int>
    {
        public int Id { get; set; }
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
