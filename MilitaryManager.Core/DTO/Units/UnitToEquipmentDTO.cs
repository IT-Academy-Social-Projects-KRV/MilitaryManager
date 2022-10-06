using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitToEquipmentDTO
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int GivenById { get; set; }
        public int DivisionId { get; set; }
        public DateTime GivenDate { get; set; }

        public DivisionDTO Division { get; set; }
        public EntityDTO Equipment { get; set; }
        public UnitDTO Unit { get; set; }
        public UnitDTO Warehouseman { get; set; }
    }
}
