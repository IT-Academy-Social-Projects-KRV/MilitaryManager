using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace MilitaryManager.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
