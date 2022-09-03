﻿using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.PositionEntity
{
    [Table("Position", Schema = "Unit")]
    public class Position : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Soldier> Soldiers { get; set; } = new List<Soldier>();
    }
}
