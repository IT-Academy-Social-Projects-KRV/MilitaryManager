using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentGenerator;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using MilitaryManager.Infrastructure;
using MilitaryManager.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MilitaryManager.Core.Services.StoreService;
using MilitaryManager.Infrastructure.StoreConfig;

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
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(opt =>
               {
                   var identityUrl = Configuration.GetValue<string>("IdentityUrl");

                   opt.RequireHttpsMetadata = false;
                   opt.Authority = identityUrl;
                   opt.Audience = "attachmentsAPI";
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       // As issuer is HTTPS localhost, and authority is HTTP docker, but should be the same
                       ValidateIssuer = false

                   };
               });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Attachments", new OpenApiInfo { Title = "Attachment", Version = "v1" });
            });

            services.AddCustomAttachmentsServices();
            services.AddAutoMapper();
            services.AddRepositories();
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddHttpContextAccessor();

            services.AddStoreService(Configuration);
            services.AddTransient<StoreService>();

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

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Attachments/swagger.json", "Attachment V1");
            });

            app.UseCors(
                builder => builder
                    .WithOrigins("http://localhost:4200", "https://localhost:5001", "http://localhost:5000", "http://localhost:5003")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
