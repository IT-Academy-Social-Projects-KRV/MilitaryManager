using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public UnitDTO Parent { get; set; }

        public ICollection<UnitDTO> SubUnits { get; set; }
    }
}
