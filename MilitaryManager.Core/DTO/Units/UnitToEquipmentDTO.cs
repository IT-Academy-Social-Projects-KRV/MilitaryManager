
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.Entities.DivisionEntity;

using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;
using MilitaryManager.Core.DTO.Attributes;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitToEquipmentDTO
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int? GivenById { get; set; }
        public int DivisionId { get; set; }
        public DateTime? GivenDate { get; set; }

        public DivisionDTO Division { get; set; }
        public EntityDTO Equipment { get; set; }
        public UnitDTO Unit { get; set; }
        public UnitDTO Warehouseman { get; set; }
    }

    public class UnitToEquipmentWithValueDTO
    {
        public int Id { get; set; }
        public string RegNum { get; set; }
        public string GivenByName { get; set; }
        public string DivisionName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime? GivenDate { get; set; }

        public List<AttributeWithValueDTO> NameValue { get; set; }
    }
}
