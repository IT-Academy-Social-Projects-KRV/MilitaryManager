using AutoMapper;
using MilitaryManager.Core.DTO.Profiles;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class ProfileService : IProfileService
    {
        protected readonly IRepository<Entities.ProfileEntity.Profile, int> _profileRepository;
        protected readonly IMapper _mapper;

        public async Task<ProfileDTO> CreateProfileAsync(ProfileDTO profileDTO)
        {
            var profile = _mapper.Map<Entities.ProfileEntity.Profile>(profileDTO);
            var newProfile = await _profileRepository.AddAsync(profile);
            await _profileRepository.SaveChangesAcync();

            return _mapper.Map<ProfileDTO>(newProfile);
        }
    }
}
