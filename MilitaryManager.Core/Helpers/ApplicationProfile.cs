namespace MilitaryManager.Core.Helpers
{
    public class ApplicationProfile : Profile
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
            CreateMap<EntityRequestDTO, Entity>().ReverseMap();
            CreateMap<EntityToAttributeDTO, EntityToAttribute>().ReverseMap();
            CreateMap<UnitToEquipmentDTO, UnitToEquipment>().ReverseMap();
            CreateMap<UnitToEquipmentRequestDTO, UnitToEquipment>().ReverseMap();
            CreateMap<ProfileDTO, Entities.ProfileEntity.Profile>().ReverseMap();
            CreateMap<ProfileRequestDTO, Entities.ProfileEntity.Profile>().ReverseMap();
            CreateMap<Change, ChangeDTO>();
            CreateMap<Change, ChangeDTO>().
                AfterMap((src, dest) => dest.Date = src.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            CreateMap<ChangeValue, ChangeValuesDTO>();
        }
    }
}
