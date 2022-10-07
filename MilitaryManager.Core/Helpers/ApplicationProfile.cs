using AutoMapper;
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
            CreateMap<RankDTO, Rank>().ReverseMap();
            CreateMap<AttributeDTO, Attribute>().ReverseMap();
            CreateMap<EntityDTO, Entity>().ReverseMap();
            CreateMap<EntityToAttributeDTO, EntityToAttribute>().ReverseMap();
            CreateMap<PositionDTO, Position>().ReverseMap();
            CreateMap<Profile, ProfileDTO>();
            CreateMap<UnitToEquipmentDTO, UnitToEquipment>().ReverseMap();
        }
    }
}
