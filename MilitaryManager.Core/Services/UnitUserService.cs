using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.UnitUserEntity;
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

        public UnitUserService(IRepository<UnitUser, int> unitUserRepository, IHttpContextAccessor httpContextAccessor, IUnitService unitService)
        {
            _unitUserRepository = unitUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitService = unitService;
        }

        public async Task<UnitUser> GetUnitUserAsync(string id)
        {
            var specification = new UnitUsers.UnitUserByUserId(id);
            return await _unitUserRepository.GetFirstBySpecAsync(specification);
        }

        public async Task<UnitUser> CreateUnitUserAsync(UnitDTO unit)
        {
            var newUnit = await _unitService.CreateUnitAsync(unit);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newUnitUser = await _unitUserRepository.AddAsync(new UnitUser { Id = newUnit.Id, UserId = userId });
            await _unitUserRepository.SaveChangesAcync();

            return newUnitUser;
        }
    }
}
