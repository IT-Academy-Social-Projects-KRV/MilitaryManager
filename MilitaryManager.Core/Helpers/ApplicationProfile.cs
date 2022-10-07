using AutoMapper;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
            CreateMap<Change, AuditDTO>()
                .BeforeMap((src, dest) =>
                {
                    if(src.ChangeValue != null)
                    {
                        dest.NewValue = src.ChangeValue.NewValue;
                        dest.OldValue = src.ChangeValue.OldValue;
                        dest.ColumnName = src.ChangeValue.ColumnName;
                    }
                });
        }
    }
}
