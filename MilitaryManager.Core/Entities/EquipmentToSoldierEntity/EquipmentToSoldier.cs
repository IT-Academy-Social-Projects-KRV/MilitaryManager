﻿using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EquipmentToSoldierEntity
{
    [Table("EquipmentToSoldiers", Schema = "Unit")]
    public class EquipmentToSoldier : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int GivenById { get; set; }
        public int DivisionId { get; set; }
        public DateTime GivenDate { get; set; }

        public Division Division { get; set; }
        public Entity Equipment { get; set; }
        public Unit Unit { get; set; }
        public Unit Warehouseman { get; set; }
    }
}
