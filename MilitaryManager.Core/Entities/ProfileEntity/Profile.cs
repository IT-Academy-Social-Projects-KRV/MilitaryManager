using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.ProfileEntity
{
    [Table("Profiles", Schema = "Unit")]
    public class Profile : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int UnitId { get; set; }
        public string Value { get; set; }

        public Attribute Attribute { get; set; }
        public Unit Unit { get; set; }
    }
}
