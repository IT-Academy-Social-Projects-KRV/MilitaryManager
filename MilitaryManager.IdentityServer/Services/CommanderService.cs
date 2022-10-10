using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using MilitaryManager.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MilitaryManager.IdentityServer.Services
{
    public class CommanderService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommanderService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<IEnumerable<string>> GetRoleAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;

            // var userId = "5c0670e2-ab50-4a51-8de1-20eab251217c";

            var existingUser = await _userManager.FindByIdAsync(userId);

            if(existingUser != null)
            {
                var role = await _userManager.GetRolesAsync(existingUser);

                return role;
            }

            return null;
        }
    }
}
