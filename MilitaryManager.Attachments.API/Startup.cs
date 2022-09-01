using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentGenerator;
using MilitaryManager.Attachments.API.Data;
using Microsoft.EntityFrameworkCore;
using MilitaryManager.Attachments.API.Interfaces.Repositories;
using MilitaryManager.Attachments.API.Repositories;
using MilitaryManager.Attachments.API.Interfaces;

namespace MilitaryManager.Attachments.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region repositories
            services.AddTransient<IDecreeRepository, DecreeRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IStatusHistoryRepository, StatusHistoryRepository>();
            services.AddTransient<ITemplateRepository, TemplateRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.RegisterDocumentGenerationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                builder => builder
                    .WithOrigins("http://localhost:4200", "http://localhost:5001", "http://localhost:5000", "http://localhost:5003")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
