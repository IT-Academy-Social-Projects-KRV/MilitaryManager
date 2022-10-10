using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.IdentityServer.Models;
using MilitaryManager.IdentityServer.Services;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MilitaryManager.IdentityServer.Controllers
{
    [Route("api/commander")]
    [Authorize]
    public class CommanderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly CommanderService _commanderService;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommanderController(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _commanderService = new CommanderService(_userManager, _httpContextAccessor);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCommander([FromBody]CreateUserData userData)
        {
            var user = await _commanderService.RegisterCommander(userData);

            return Ok(user);
        }

        [HttpGet]
        [Authorize(LocalApi.PolicyName)]
        public async Task<IActionResult> GetRole()
        {
            var role = await _commanderService.GetRoleAsync();
            return Ok(role);
        }
    }
}
