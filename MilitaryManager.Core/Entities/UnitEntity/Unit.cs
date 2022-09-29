using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    [Table("Units", Schema = "Unit")]
    public class Unit : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? DivisionId { get; set; }
        public int RankId { get; set; }
        public int? ParentId { get; set; }
        public int PositionId { get; set; }

        public Division Division { get; set; }
        public Rank Rank { get; set; }
        public Unit Parent { get; set; }
        public Position Position { get; set; }

        public ICollection<Unit> SubUnits { get; set; }

        public ICollection<Profile> Profiles { get; set; }
        public ICollection<EquipmentToUnit> EquipmentToUnits { get; set; }
        public ICollection<EquipmentToUnit> EquipmentToWarehouseMan { get; set; }
    }
}
