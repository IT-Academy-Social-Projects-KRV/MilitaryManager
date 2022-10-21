using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AttributeValueEntity
{
    [Table("AttributeValues", Schema = "Unit")]
    public class AttributeValue : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public Attribute Attribute { get; set; }
    }
}
