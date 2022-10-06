using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.Entities.EntityEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Entities
{
    public class EntityToAttributeDTO
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public EntityDTO Entity { get; set; }
        public AttributeDTO Attribute { get; set; }
    }
}
