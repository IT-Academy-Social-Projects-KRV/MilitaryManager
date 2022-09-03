using AutoMapper;
using MilitaryManager.Attachments.API.DTO;
using MilitaryManager.Attachments.API.Entities;

namespace MilitaryManager.Attachments.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Decree, DecreeDTO>().ReverseMap();
        }
    }
}
