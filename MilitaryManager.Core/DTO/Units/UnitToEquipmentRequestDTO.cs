using System;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitToEquipmentRequestDTO
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int GivenById { get; set; }
        public int DivisionId { get; set; }
        public DateTime GivenDate { get; set; }
    }
}
