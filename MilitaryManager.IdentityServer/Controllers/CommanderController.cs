using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.IdentityServer.Models;
using System.Threading.Tasks;

namespace MilitaryManager.IdentityServer.Controllers
{
    [Route("commander")]
    [Authorize]
    public class CommanderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CommanderController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCommander([FromBody]CreateUserData userData)
        {
            var existingUser = await _userManager.FindByNameAsync(userData.Username);

            if (existingUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = userData.Username,
                    Email = userData.Username,
                };

                var result = await _userManager.CreateAsync(user, userData.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userData.Role);
                }
            }
            return Ok();
        }
    }
}
