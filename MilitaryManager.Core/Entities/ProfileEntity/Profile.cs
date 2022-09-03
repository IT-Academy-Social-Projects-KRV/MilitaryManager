using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.ProfileEntity
{
    [Table("Profile", Schema = "Unit")]
    public class Profile : IBaseEntity
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int SoldierId { get; set; }
        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Soldier Soldier { get; set; }
    }
}
