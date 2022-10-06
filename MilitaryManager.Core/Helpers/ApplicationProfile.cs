using AutoMapper;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.DivisionEntity;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
        }
    }
}
