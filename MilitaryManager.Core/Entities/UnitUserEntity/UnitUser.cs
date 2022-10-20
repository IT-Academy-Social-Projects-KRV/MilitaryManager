using MilitaryManager.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    [Table("UnitUsers", Schema = "Unit")]
    public class UnitUser : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Unit Unit { get; set; }
    }
}
