using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilitaryManager.Attachments.API.Services.StoreService;


namespace MilitaryManager.Attachments.API.StoreConfig
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
                    services.AddTransient<IStoreService, AzureStoreService>();
                    break;
            }
        }
    }
}
