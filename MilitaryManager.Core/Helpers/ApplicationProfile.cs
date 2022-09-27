using AutoMapper;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.UnitEntity;

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
        }
    }
}
