using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public virtual UnitDTO Parent { get; set; }

        public virtual ICollection<UnitDTO> SubUnits { get; set; }
    }
}
