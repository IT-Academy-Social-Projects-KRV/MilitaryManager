using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Entities
{
    public class EntityRequestDTO
    {
        public int Id { get; set; }
        public string RegNum { get; set; }
        public List<EntityToAttributeDTO> EntityToAttributes { get; set; }
    }
}
