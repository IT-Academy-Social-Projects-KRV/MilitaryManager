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
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using System.IO;
using System.Linq;

namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap()
                .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Rank.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<UnitRequestDTO, Unit>().ReverseMap();
            CreateMap<Decree, DecreeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Template, opt => opt.MapFrom(src => src.Template.Type))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => Path.GetFileName(src.Path)))
                .ForMember(dest => dest.PathSigned, opt => opt.MapFrom(src => Path.GetFileName(src.SignedPdf.Path)));
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<DivisionDTO, Division>().ReverseMap();
            CreateMap<DivisionRequestDTO, Division>().ReverseMap();
            CreateMap<RankDTO, Rank>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<AttributeDTO, Attribute>().ReverseMap();
            CreateMap<EntityDTO, Entity>().ReverseMap();
            CreateMap<EntityRequestDTO, Entity>().ReverseMap()
                .ForMember(dest => dest.Division, opt => opt.MapFrom(src => src.UnitToEquipment.Division))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.UnitToEquipment.Unit))
                .ForMember(dest => dest.Warehouseman, opt => opt.MapFrom(src => src.UnitToEquipment.GivenBy))
                .ForMember(dest => dest.GivenDate, opt => opt.MapFrom(src => src.UnitToEquipment.GivenDate));
            CreateMap<EntityToAttributeDTO, EntityToAttribute>().ReverseMap();
            CreateMap<EntityToAttributeRequestDTO, EntityToAttribute>().ReverseMap()
                .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.Name));
            CreateMap<UnitToEquipmentDTO, UnitToEquipment>().ReverseMap();
            CreateMap<UnitToEquipmentRequestDTO, UnitToEquipment>().ReverseMap();
            CreateMap<ProfileDTO, Entities.ProfileEntity.Profile>().ReverseMap();
            CreateMap<ProfileRequestDTO, Entities.ProfileEntity.Profile>().ReverseMap();
            CreateMap<Change, ChangeDTO>().
                AfterMap((src, dest) => dest.Date = src.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            CreateMap<ChangeValue, ChangeValuesDTO>();
            CreateMap<Profile, AttributeWithValueDTO>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Attribute.Name));

            CreateMap<UnitToEquipment, UnitToEquipmentWithValueDTO>()
                .ForMember(dest => dest.RegNum, opt => opt.MapFrom(src => src.Equipment.RegNum))
                .ForMember(dest => dest.GivenByName,
                    opt => opt.MapFrom(src => src.GivenBy.LastName + " " + src.GivenBy.FirstName + " " + src.GivenBy.SecondName))
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.Name))
                .ForMember(dest => dest.NameValue, opt => opt.MapFrom(src => src.Equipment.EntityToAttributes));

            //.ForMember(dest => dest.Value,
            //    opt => opt.MapFrom(src =>
            //        src.Equipment.EntityToAttributes.FirstOrDefault(x => x.EntityId == src.Equipment.Id).Value))
            //.ForMember(dest => dest.Name,
            //    opt => opt.MapFrom(src =>
            //        src.Equipment.EntityToAttributes.FirstOrDefault(x => x.EntityId == src.Equipment.Id).Attribute
            //            .Name));

            CreateMap<EntityToAttribute, AttributeWithValueDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Attribute.Name));
        }
    }
}
