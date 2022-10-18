// using AutoMapper;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.DTO.Profiles;
using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.Entities.ProfileEntity;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap()
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Rank.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<Decree, DecreeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Template, opt => opt.MapFrom(src => src.Template.Type))
                .ForMember(dest => dest.PathSigned, opt => opt.MapFrom(src => src.SignedPdf.Path));
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
            CreateMap<AttributeDTO, Attribute>().ReverseMap();
            CreateMap<EntityDTO, Entity>().ReverseMap();
            CreateMap<EntityToAttributeDTO, EntityToAttribute>().ReverseMap();
            CreateMap<UnitToEquipmentDTO, UnitToEquipment>().ReverseMap();
            CreateMap<Rank, RankDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<Profile, ProfileDTO>().ReverseMap();

            CreateMap<Profile, AttributeWithValueDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Attribute.Name));



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
