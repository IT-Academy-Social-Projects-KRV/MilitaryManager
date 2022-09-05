using MilitaryManager.Core.Entities.EquipmentToSoldierEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.SoldierEntity
{
    [Table("Soldier", Schema = "Unit")]
    public class Soldier : IBaseEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? UnitId { get; set; }
        public int RankId { get; set; }
        public int? ParentId { get; set; }
        public int PositionId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Soldier Parent { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<Soldier> SubSoldiers { get; set; }

        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<EquipmentToSoldier> EquipmentToSoldiers { get; set; } = new HashSet<EquipmentToSoldier>();
        public ICollection<EquipmentToSoldier> EquipmentToWarehouseMan { get; set; } = new HashSet<EquipmentToSoldier>();
    }
}
