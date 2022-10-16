using MilitaryManager.Core.DTO.Profiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IProfileService
    {
        Task<ProfileDTO> CreateProfileAsync(ProfileDTO profile);
    }
}
