using MilitaryManager.Core.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Entities
{
    public class EntityToAttributeRequestDTO
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
        public string AttributeName { get; set; }
    }
}
