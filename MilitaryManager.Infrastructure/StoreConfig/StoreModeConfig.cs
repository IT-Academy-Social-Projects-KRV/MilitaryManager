using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Core.Services;
using MilitaryManager.Core.Services.StoreService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Infrastructure.StoreConfig
{
    public static class StoreModeConfig
    {
        public static void AddStoreService(this IServiceCollection services, IConfiguration configuration)
        {
            string mode = configuration.GetValue<string>("StoreMode:Mode");
            switch (mode)
            {
                case "Local":
                    services.AddTransient<IStoreService, LocalStoreService>();
                    break;
                case "Azure":
                    services.AddTransient<IStoreService, AzureStoreService>();
                    break;
                case "AzureDockerContainer":
                    services.AddTransient<IStoreService, DockerContainerStoreService>();
                    break;
            }
        }
    }
}
