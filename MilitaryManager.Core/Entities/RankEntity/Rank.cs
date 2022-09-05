using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.RankEntity
{
    [Table("Rank", Schema = "Unit")]
    public class Rank : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Soldier> Soldiers { get; set; } = new HashSet<Soldier>();
    }
}
