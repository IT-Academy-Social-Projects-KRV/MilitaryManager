using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core
{
    public static class StartupSetup
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
        }
    }
}
