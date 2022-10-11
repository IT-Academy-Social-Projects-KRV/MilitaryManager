using AutoMapper;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.DTO.Positions;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<Decree, DecreeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Template, opt => opt.MapFrom(src => src.Template.Type))
                .ForMember(dest => dest.PathSigned, opt => opt.MapFrom(src => src.SignedPdf.Path));
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
            CreateMap<Rank, RankDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
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
