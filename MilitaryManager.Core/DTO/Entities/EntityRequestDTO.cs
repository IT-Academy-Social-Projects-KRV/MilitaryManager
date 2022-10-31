using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Entities
{
    public class EntityRequestDTO
    {
        public int Id { get; set; }
        public string RegNum { get; set; }
        public DivisionRequestDTO Division { get; set; }

        public List<EntityToAttributeRequestDTO> EntityToAttributes { get; set; }
        public DateTime? GivenDate { get; set; }
        public UnitRequestDTO Unit { get; set; }
        public UnitRequestDTO Warehouseman { get; set; }
    }
}
