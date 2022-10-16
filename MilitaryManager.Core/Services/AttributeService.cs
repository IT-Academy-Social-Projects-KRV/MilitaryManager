using AutoMapper;
using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class AttributeService: IAttributeService
    {
        protected readonly IRepository<Entities.AttributeEntity.Attribute, int> _attributeRepository;
        protected readonly IMapper _mapper;

        public AttributeService(IRepository<Entities.AttributeEntity.Attribute, int> attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<AttributeDTO>> GetAllAttributesAsync()
        {
            var attributes = await _attributeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AttributeDTO>>(attributes);
        }
    }
}
