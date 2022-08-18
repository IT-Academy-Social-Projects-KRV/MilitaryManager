using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

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
	}

}
