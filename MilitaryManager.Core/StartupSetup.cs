using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Helpers;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;

namespace MilitaryManager.Core
{
    public static class StartupSetup
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IDecreeService, DecreeService>();
            services.AddScoped<ITemplateService, TemplateService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
