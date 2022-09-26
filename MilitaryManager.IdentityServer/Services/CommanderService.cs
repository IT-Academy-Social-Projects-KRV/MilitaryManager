using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using MilitaryManager.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MilitaryManager.IdentityServer.Services
{
    public class CommanderService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CommanderService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> RegisterCommander(CreateUserData userData )
        {
            var existingUser = await _userManager.FindByNameAsync(userData.Username);

            if (existingUser != null)
            {
                throw new Exception("this user exsits");
            }
            var user = new ApplicationUser
            {
                UserName = userData.Username,
                Email = userData.Username,
            };

            var result = await _userManager.CreateAsync(user, userData.Password);
            if (!result.Succeeded)
            {
                var messages = result.Errors.Select((err) => err.Description);
                var message = string.Join(' ', messages);
                throw new Exception(message);
            }

            await _userManager.AddToRoleAsync(user, userData.Role);

            return user;
        }
    }
}
