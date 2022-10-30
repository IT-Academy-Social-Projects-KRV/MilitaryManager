using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Helpers;
using MilitaryManager.Core.Helpers.Policy;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;

namespace MilitaryManager.Core
{
    public static class StartupSetup
    {
        public static void AddCustomUnitsServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IRankService, RankService>();
            services.AddScoped<IUnitUserService, UnitUserService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IAttributeService, AttributeService>();
        }
        public static void AddCustomAttachmentsServices(this IServiceCollection services)
        {
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

        public static void AddPolicyServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorizationHandler, WorkspaceRolesAuthorizationHandler>();
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("DivisionIdLimit",
                    policy => policy.Requirements.Add(new WorkspaceRolesRequirement()));
            });
        }
    }
}
