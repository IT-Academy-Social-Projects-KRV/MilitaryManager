using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.DTO.Profiles;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Attributes
{
    public class AttributeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProfileDTO> Profiles { get; set; }
        public List<EntityToAttributeDTO> EntityToAttributes { get; set; }
    }

    public class AttributeWithValueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    //List<AttributeWithValueDTO>
}
