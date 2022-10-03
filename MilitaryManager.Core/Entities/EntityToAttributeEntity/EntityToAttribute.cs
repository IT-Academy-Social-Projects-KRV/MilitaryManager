using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EntityToAttributeEntity
{
    [Table("EntityToAttributes", Schema = "Unit")]
    public class EntityToAttribute : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public Entity Entity { get; set; }
        public Attribute Attribute { get; set; }
    }
}
