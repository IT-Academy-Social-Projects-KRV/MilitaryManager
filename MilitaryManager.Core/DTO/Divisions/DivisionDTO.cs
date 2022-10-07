using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Divisions
{
    public class DivisionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }

        public DivisionDTO Parent { get; set; }

        public List<DivisionDTO> SubDivisions { get; set; }
    }
}
