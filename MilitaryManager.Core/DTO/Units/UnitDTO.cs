using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.RankEntity;
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

        //public DivisionDTO Division { get; set; }
        public RankDTO Rank { get; set; }
        public UnitDTO Parent { get; set; }
        public PositionDTO Position { get; set; }

        public List<UnitDTO> SubUnits { get; set; }

        public List<ProfileDTO> Profiles { get; set; }
        public List<UnitToEquipmentDTO> UnitToEquipments { get; set; }
        public List<UnitToEquipmentDTO> EquipmentToWarehouseMan { get; set; }

    }
}
