using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Units
{
    public class AttributeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProfileDTO> Profiles { get; set; }
        public List<EntityToAttributeDTO> EntityToAttributes { get; set; }
    }
}
