using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.IdentityServer.Models;
using MilitaryManager.IdentityServer.Services;
using System.Threading.Tasks;

namespace MilitaryManager.IdentityServer.Controllers
{
    [Route("api/commander")]
    [Authorize]
    public class CommanderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly CommanderService _commanderService;
        public CommanderController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _commanderService = new CommanderService(_userManager);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCommander([FromBody]CreateUserData userData)
        {
            var user = await _commanderService.RegisterCommander(userData);

            return Ok(user);
        }
    }
}
