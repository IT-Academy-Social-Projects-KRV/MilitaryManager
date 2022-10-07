﻿using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.DTO.Profiles;
using MilitaryManager.Core.DTO.Ranks;
using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Units
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int? DivisionId { get; set; }
        public int RankId { get; set; }
        public int? ParentId { get; set; }
        public int PositionId { get; set; }

        public DivisionDTO Division { get; set; }
        public RankDTO Rank { get; set; }
        public UnitDTO Parent { get; set; }
        public PositionDTO Position { get; set; }

        public List<UnitDTO> SubUnits { get; set; }

        public List<ProfileDTO> Profiles { get; set; }
        public List<UnitToEquipmentDTO> UnitToEquipments { get; set; }
        public List<UnitToEquipmentDTO> EquipmentToWarehouseMan { get; set; }

    }
}
