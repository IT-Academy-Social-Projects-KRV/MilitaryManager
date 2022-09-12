using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class Unit : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public virtual Unit Parent { get; set; }

        public virtual ICollection<Unit> SubUnits { get; set; }
    }
}
