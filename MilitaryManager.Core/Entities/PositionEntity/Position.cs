using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.PositionEntity
{
    [Table("Positions", Schema = "Unit")]
    public class Position : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Soldier> Soldiers { get; set; } = new HashSet<Soldier>();
    }
}
