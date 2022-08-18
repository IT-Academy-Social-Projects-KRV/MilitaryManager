using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MilitaryManager.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace MilitaryManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHsts(ConfigureHsts)
                .AddHttpsRedirection(ConfigureHttpsRedirection);

            // Read configuration
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));

            // MVC Options
            services.AddMvc();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/dist";
            });

            // ASP.NET Core workaround for Newtonsoft.Json.JsonSerializer
            // When output formatter buffering is supressed,
            // synchronous operations must be enabled
            // https://github.com/dotnet/aspnetcore/issues/7644
            // services.Configure<KestrelServerOptions>(opt => opt.AllowSynchronousIO = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Add request-based middleware
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseCors(
                builder => builder
                    .WithOrigins("http://localhost:4200", "http://localhost:5001", "http://localhost:5000")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            //app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "wwwroot/dist";
            });
        }

        private void ConfigureHsts(HstsOptions options)
        {
            // Default HSTS age is 30 days, but 1 year is best practice.
            options.MaxAge = TimeSpan.FromDays(365);
        }

        private void ConfigureHttpsRedirection(HttpsRedirectionOptions options)
        {
            // Default redirect is via status 307, which is OK.
        }

        private void JsonOptions(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
