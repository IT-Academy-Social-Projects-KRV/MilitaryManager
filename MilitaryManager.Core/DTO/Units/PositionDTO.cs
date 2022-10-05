using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Units
{
    public class PositionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UnitDTO> Units { get; set; }
    }
}
