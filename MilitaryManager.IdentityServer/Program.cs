using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace MilitaryManager.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                RolesData.SeedRoles(serviceProvider).Wait();

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                const string USERNAME = "myadmin@myadmin.com";
                const string PASSWORD = "Admin1@";

                var existingUser = userManager.FindByNameAsync(USERNAME).Result;

                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = USERNAME,
                        Email = USERNAME,
                    };

                    var result = userManager.CreateAsync(user, PASSWORD).Result;
                    if (result.Succeeded)
                    {
                       userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(ConfigureWebHost);

        [ExcludeFromCodeCoverage]
        private static void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureKestrel(o => o.AddServerHeader = false);
            builder.UseStartup<Startup>();
        }
    }
}
