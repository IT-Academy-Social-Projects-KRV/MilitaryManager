using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;

namespace MilitaryManager.Core
{
    public static class StartupSetup
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitServices, UnitServices>();
        }
    }
}
