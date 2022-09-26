using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Interfaces;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Infrastructure.Data;
using MilitaryManager.Infrastructure.Data.Repositories;

namespace MilitaryManager.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
            // Test
            services.AddScoped<IStoreService, TestStore>();
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MilitaryManagerDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
