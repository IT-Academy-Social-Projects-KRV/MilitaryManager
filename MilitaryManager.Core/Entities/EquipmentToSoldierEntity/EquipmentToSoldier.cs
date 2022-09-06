using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EquipmentToSoldierEntity
{
    [Table("EquipmentToSoldiers", Schema = "Unit")]
    public class EquipmentToSoldier : IBaseEntity
    {
        public int EquipmentId { get; set; }
        public int? SoldierId { get; set; }
        public int GivenById { get; set; }
        public int UnitId { get; set; }
        public DateTime GivenDate { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual Entity Equipment { get; set; }
        public virtual Soldier Soldier { get; set; }
        public virtual Soldier Warehouseman { get; set; }
    }
}
