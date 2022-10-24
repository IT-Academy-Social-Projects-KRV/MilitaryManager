using AutoMapper;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.DTO.Profiles;
using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using System.IO;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap()
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Rank.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<Decree, DecreeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Template, opt => opt.MapFrom(src => src.Template.Type))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => Path.GetFileName(src.Path)))
                .ForMember(dest => dest.PathSigned, opt => opt.MapFrom(src => Path.GetFileName(src.SignedPdf.Path)));
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
            CreateMap<RankDTO, Rank>().ReverseMap();
            CreateMap<AttributeDTO, Attribute>().ReverseMap();
            CreateMap<EntityDTO, Entity>().ReverseMap();
            CreateMap<EntityToAttributeDTO, EntityToAttribute>().ReverseMap();
            CreateMap<PositionDTO, Position>().ReverseMap();
            CreateMap<UnitToEquipmentDTO, UnitToEquipment>().ReverseMap();
            CreateMap<ProfileDTO, Entities.ProfileEntity.Profile>().ReverseMap();
            CreateMap<Change, ChangeDTO>().
                AfterMap((src, dest) => dest.Date = src.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            CreateMap<ChangeValue, ChangeValuesDTO>();
        }
    }
}
