using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToSoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EntityEntity
{
    [Table("Entity", Schema = "Unit")]
    public class Entity : IBaseEntity
    {
        public int Id { get; set; }
        public string RegNum { get; set; }

        public List<EntityToAttribute> EntityToAttributes { get; set; } = new List<EntityToAttribute>();
        public EquipmentToSoldier EquipmentToSoldiers { get; set; } = new EquipmentToSoldier();
    }
}
