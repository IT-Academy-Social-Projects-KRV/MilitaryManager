using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.EntityToAttributeEntity
{
    [Table("EntityToAttribute", Schema = "Unit")]
    public class EntityToAttribute : IBaseEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}
