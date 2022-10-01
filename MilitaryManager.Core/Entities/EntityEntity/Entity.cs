using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EntityEntity
{
    [Table("Entities", Schema = "Unit")]
    public class Entity : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string RegNum { get; set; }

        public ICollection<EntityToAttribute> EntityToAttributes { get; set; }
        public UnitToEquipment UnitToEquipment { get; set; }
    }
}
