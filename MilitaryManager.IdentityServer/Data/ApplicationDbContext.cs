using IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		private static readonly bool[] _migrated = { false };
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			if (!_migrated[0])
			{
				lock (_migrated)
					if (!_migrated[0])
					{
						Database.Migrate();
						_migrated[0] = true;
					}
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}
	}
}
