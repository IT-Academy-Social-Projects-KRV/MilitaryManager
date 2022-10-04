using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.StatusHistoryEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.StatusEntity
{
    public class Status : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Decree> Decrees { get; set; }
        public ICollection<StatusHistory> OldStatuses { get; set; }
        public ICollection<StatusHistory> NewStatuses { get; set; }
    }
}
