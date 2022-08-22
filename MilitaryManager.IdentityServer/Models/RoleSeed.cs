using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;

namespace IdentityServer.Data
{
	public enum Roles
	{
		User,
		Admin
	}

	public static class RolesData
	{
		public static async Task SeedRoles(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

				if (dbContext.Database.GetPendingMigrations().Any())
				{
					await dbContext.Database.MigrateAsync();
				}
				var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

				foreach (var role in Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(r => r.ToString()))
				{
					if (!await roleManager.RoleExistsAsync(role))
					{
						await roleManager.CreateAsync(new IdentityRole(role));
					}
				}
			}
		}

       /* public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var context = provider.GetRequiredService<ApplicationDbContext>();
                var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                // automigration 
                context.Database.Migrate();
                InstallUsers(userManager, roleManager);
            }
        }

        private static void InstallUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            const string USERNAME = "admin@mysite.com";
            const string PASSWORD = "123456ABCD";
            const string ROLENAME = "testRazRaz";

            var roleExist = roleManager.RoleExistsAsync(ROLENAME).Result;
            if (!roleExist)
            {
                //create the roles and seed them to the database
                roleManager.CreateAsync(new IdentityRole<Guid>(ROLENAME)).GetAwaiter().GetResult();
            }

            var user = userManager.FindByNameAsync(USERNAME).Result;

            if (user == null)
            {
                var serviceUser = new ApplicationUser
                {
                    UserName = USERNAME,
                    Email = USERNAME
                };

                var createPowerUser = userManager.CreateAsync(serviceUser, PASSWORD).Result;
                if (createPowerUser.Succeeded)
                {
                    var confirmationToken = userManager.GenerateEmailConfirmationTokenAsync(serviceUser).Result;
                    var result = userManager.ConfirmEmailAsync(serviceUser, confirmationToken).Result;
                    //here we tie the new user to the role
                    userManager.AddToRoleAsync(serviceUser, ROLENAME).GetAwaiter().GetResult();
                }
            }
        }*/
    }

}
