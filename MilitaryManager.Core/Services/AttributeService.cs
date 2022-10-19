using AutoMapper;
using MilitaryManager.Core.DTO.Attributes;
using MilitaryManager.Core.Entities.AttributeValueEntity;
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
        protected readonly IRepository<AttributeValue, int> _attributeValueRepository;
        protected readonly IMapper _mapper;

        public AttributeService(IRepository<Entities.AttributeEntity.Attribute, int> attributeRepository, IRepository<AttributeValue, int> attributeValueRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _attributeValueRepository = attributeValueRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<AttributeDTO>> GetAllAttributesAsync()
        {
            var attributes = await _attributeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AttributeDTO>>(attributes);
        }

        public async Task<IEnumerable<string>> GetAttributeValuesByKeyAsync(int id)
        {
            var attributeValues = await _attributeValueRepository.GetListBySpecAsync(new AttributeValues.ValuesById(id));
            List<string> values = new List<string>();

            foreach (var item in attributeValues)
            {
                values.Add(item.Value);
            }
            return values;
        }
    }
}
