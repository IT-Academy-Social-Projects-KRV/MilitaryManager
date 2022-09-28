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
        Admin,
        UnitCommander,
        SubUnitCommander
    }

    public static class RolesData
    {
        public static async Task SeedRoles(IServiceProvider app)
        {
           var dbContext = app.GetService<ApplicationDbContext>();
        
           if (dbContext.Database.GetPendingMigrations().Any())
           {
             await dbContext.Database.MigrateAsync();
           }

           var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();
        
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


