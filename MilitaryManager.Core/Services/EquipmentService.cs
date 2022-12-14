using AutoMapper;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class EquipmentService: IEquipmentService
    {
        protected readonly IRepository<Entity, int> _entityRepository;
        protected readonly IRepository<EntityToAttribute, int> _entityToAttributeRepository;
        protected readonly IRepository<UnitToEquipment, int> _unitToEquipmentRepository;
        protected readonly IMapper _mapper;
        public EquipmentService(IRepository<Entity, int> entityRepository,
            IMapper mapper, IRepository<EntityToAttribute, int> entityToAttributeRepository,
            IRepository<UnitToEquipment, int> unitToEquipmentRepository)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _entityToAttributeRepository = entityToAttributeRepository; 
            _unitToEquipmentRepository = unitToEquipmentRepository;
        }
        public async Task<EntityRequestDTO> CreateEntityAsync(EntityRequestDTO dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            var newEntity = await _entityRepository.AddAsync(entity);
            await _entityRepository.SaveChangesAcync();

            var unitToEquip = new UnitToEquipment{ 
                Id = newEntity.Id,
                DivisionId = dto.Division.Id,
                GivenById = dto.Warehouseman?.Id,
                GivenDate = dto.GivenDate,
                UnitId = dto.Unit?.Id };

            await _unitToEquipmentRepository.AddAsync(unitToEquip);
            await _unitToEquipmentRepository.SaveChangesAcync();

            return _mapper.Map<EntityRequestDTO>(newEntity);
        }
        public async Task<IEnumerable<EntityRequestDTO>> GetEquipmentAsync()
        {
            var equipment = await _entityRepository.GetListBySpecAsync(new EntitiesSpec.GetEntities());

            return _mapper.Map<IEnumerable<EntityRequestDTO>>(equipment);
        }
        public async Task<EntityRequestDTO> GetEquipmentByIdAsync(int id)
        {
            var equipment = await _entityRepository.GetFirstBySpecAsync(new EntitiesSpec.EntityById(id));
         
            return _mapper.Map<EntityRequestDTO>(equipment);
        }
        public async Task<EntityRequestDTO> UpdateEntityAsync(EntityRequestDTO dto)
        {
            var entity = _mapper.Map<Entity>(dto);
            foreach (var value in dto.EntityToAttributes)
            {
                var entityToAttribute = _mapper.Map<EntityToAttribute>(value);
                await _entityToAttributeRepository.UpdateAsync(entityToAttribute);
                await _entityToAttributeRepository.SaveChangesAcync();
            }
            var updateEntity = await _entityRepository.UpdateAsync(entity);
            await _entityRepository.SaveChangesAcync();

            return _mapper.Map<EntityRequestDTO>(updateEntity);
        }
        public async Task<EntityRequestDTO> DeleteEntityAsync(int id)
        {
            var entity = await _entityRepository.GetByKeyAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Unit not found");
            }
            var deleteEntity = await _entityRepository.DeleteAsync(entity);
            await _entityRepository.SaveChangesAcync();

            return _mapper.Map<EntityRequestDTO>(deleteEntity);
        }
    }
}
