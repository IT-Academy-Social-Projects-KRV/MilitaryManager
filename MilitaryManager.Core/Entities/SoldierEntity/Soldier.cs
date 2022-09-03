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
        public int? RankId { get; set; }
        public int? PatronymicId { get; set; }
        public int? PositionId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Soldier Patronymic { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<Soldier> SubSoldiers { get; set; }

        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<EquipmentToSoldier> EquipmentToSoldiers { get; set; } = new List<EquipmentToSoldier>();
        public List<EquipmentToSoldier> EquipmentToWarehouseMan { get; set; } = new List<EquipmentToSoldier>();
    }
}
