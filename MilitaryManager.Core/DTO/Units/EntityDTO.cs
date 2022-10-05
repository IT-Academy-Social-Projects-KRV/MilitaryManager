using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Units
{
    public class EntityDTO
    {
        public int Id { get; set; }
        public string RegNum { get; set; }

        public List<EntityToAttributeDTO> EntityToAttributes { get; set; }
        public UnitToEquipmentDTO UnitToEquipment { get; set; }
    }
}
