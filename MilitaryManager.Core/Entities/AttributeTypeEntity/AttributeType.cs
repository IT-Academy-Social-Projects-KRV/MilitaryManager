using MilitaryManager.Core.Entities.AttributeEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AttributeTypeEntity
{
    [Table("AttributeTypes", Schema = "Unit")]
    public class AttributeType
    {
       public string Name { get; set; }

        public ICollection<Attribute> Attributes { get; set; }
    }
}
