using MilitaryManager.Core.Entities.EquipmentToSoldierEntity;
using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    [Table("Unit", Schema = "Unit")]
    public class Unit : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public virtual Unit Parent { get; set; }

        public virtual ICollection<Unit> SubUnits { get; set; }

        public List<Soldier> Soldiers { get; set; } = new List<Soldier>();
        public List<EquipmentToSoldier> EquipmentToSoldiers { get; set; } = new List<EquipmentToSoldier>();
    }
}