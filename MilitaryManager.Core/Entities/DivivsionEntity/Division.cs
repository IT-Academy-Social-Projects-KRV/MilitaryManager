using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.DivisionEntity
{
    [Table("Divisions", Schema = "Unit")]
    public class Division : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DivisionNumber { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public Division Parent { get; set; }

        public ICollection<Division> SubDivisions { get; set; }

        public ICollection<Unit> Units { get; set; }
        public ICollection<UnitToEquipment> UnitToEquipments { get; set; }
    }
}