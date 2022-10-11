using IdentityServer.Models;
using MilitaryManager.IdentityServer.Models;
using System.Threading.Tasks;

namespace MilitaryManager.IdentityServer.Services
{
    public interface ICommanderService
    {
        Task<ApplicationUser> RegisterCommander(CreateUserData userData);
    }
}
