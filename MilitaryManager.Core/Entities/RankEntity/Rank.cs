using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.RankEntity
{
    [Table("Ranks", Schema = "Unit")]
    public class Rank : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
