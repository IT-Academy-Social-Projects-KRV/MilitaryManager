using MilitaryManager.Core.Entities.UnitEntity;
using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? DivisionId { get; set; }
        public int RankId { get; set; }
        public int? ParentId { get; set; }
        public int PositionId { get; set; }

        public List<Unit> SubUnits { get; set; }
    }
}
