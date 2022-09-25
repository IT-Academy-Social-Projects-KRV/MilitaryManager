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
            CreateMap<Decree, DecreeDTO>().ReverseMap();
            CreateMap<Template, TemplateDTO>().ReverseMap();
        }
    }
}
