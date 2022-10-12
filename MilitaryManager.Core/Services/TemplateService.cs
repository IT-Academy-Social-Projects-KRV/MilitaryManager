using AutoMapper;
using Microsoft.Extensions.Logging;
using MilitaryManager.Core.DTO.Attachments;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class TemplateService : ITemplateService
    {
        protected readonly IRepository<Template, int> _templateRepository;
        protected readonly IMapper _mapper;

        public TemplateService(IRepository<Template, int> templateRepository, 
                               IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateDTO>> GetTemplatesAsync()
        {
            var templates = await _templateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TemplateDTO>>(templates);
        }
    }
}
