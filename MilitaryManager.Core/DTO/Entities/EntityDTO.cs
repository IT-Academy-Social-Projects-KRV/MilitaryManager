using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Entities
{
    public class EntityDTO
    {
        public int Id { get; set; }
        public string RegNum { get; set; }

        public List<EntityToAttributeDTO> EntityToAttributes { get; set; }
        public UnitToEquipmentDTO UnitToEquipment { get; set; }
    }
}
