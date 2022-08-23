using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MilitaryManager.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MilitaryManagerDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
