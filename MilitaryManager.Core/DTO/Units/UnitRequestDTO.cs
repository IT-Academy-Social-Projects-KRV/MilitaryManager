using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.DTO.Profiles;
using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitRequestDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int? DivisionId { get; set; }
        public int RankId { get; set; }
        public int? ParentId { get; set; }
        public int PositionId { get; set; }
        //public List<AttributeWithValueDTO> Profiles { get; set; }

        public List<ProfileRequestDTO> Profiles { get; set; }
        public List<UnitToEquipmentRequestDTO> UnitToEquipments { get; set; }
    }
}
