using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitUserService : IUnitUserService
    {
        protected readonly IRepository<UnitUser, int> _unitUserRepository;
        protected readonly IUnitService _unitService;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public UnitUserService(IRepository<UnitUser, int> unitUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitUserRepository = unitUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UnitUser> GetUnitUserByKeyAsync(int id)
        {
            return await _unitUserRepository.GetByKeyAsync(id);
        }

        public async Task<UnitUser> CreateUnitUserAsync(UnitDTO unit)
        {
            var newUnit = await _unitService.CreateUnitAsync(unit);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newUnitUser = await _unitUserRepository.AddAsync(new UnitUser { Id = newUnit.Id, UserId = userId });

            return newUnitUser;
        }
    }
}
