using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MilitaryManager.Core;
using MilitaryManager.Infrastructure;
using System.Collections.Generic;

namespace MilitaryManager.Units.API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(opt =>
               {
                   var identityUrl = Configuration.GetValue<string>("IdentityUrl");

                   opt.RequireHttpsMetadata = false;
                   opt.Authority = identityUrl;
                   opt.Audience = "unitsAPI";
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       // As issuer is HTTPS localhost, and authority is HTTP docker, but should be the same
                       ValidateIssuer = false,
                   };
               });
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Description = "Basic auth added to authorization header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "basic",
                    Type = SecuritySchemeType.Http
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Basic" }
                        },
                        new List<string>()
                    }
                });
                c.SwaggerDoc("Units", new OpenApiInfo { Title = "Unit", Version = "v1" });
                c.SwaggerDoc("Divisions", new OpenApiInfo { Title = "Division", Version = "v1" });
                c.SwaggerDoc("Audit", new OpenApiInfo { Title = "Audit", Version = "v1" });
                c.SwaggerDoc("UnitUsers", new OpenApiInfo { Title = "UnitUsers", Version = "v1" });
                c.SwaggerDoc("UnitsInfo", new OpenApiInfo { Title = "UnitInfo", Version = "v1" });
                c.SwaggerDoc("Positions", new OpenApiInfo { Title = "Positions", Version = "v1" });
                c.SwaggerDoc("Ranks", new OpenApiInfo { Title = "Ranks", Version = "v1" });
            });
            services.AddCustomUnitsServices();
            services.AddAutoMapper();
            services.AddRepositories();
            services.AddPolicyServices();
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Units/swagger.json", "Unit V1");
                c.SwaggerEndpoint("/swagger/Divisions/swagger.json", "Division V1");
                c.SwaggerEndpoint("/swagger/Audit/swagger.json", "Audit V1");
                c.SwaggerEndpoint("/swagger/UnitUsers/swagger.json", "UnitUser V1");
                c.SwaggerEndpoint("/swagger/UnitsInfo/swagger.json", "UnitInfo V1");
                c.SwaggerEndpoint("/swagger/Positions/swagger.json", "Positions V1");
                c.SwaggerEndpoint("/swagger/Ranks/swagger.json", "Ranks V1");
            });

            app.UseCors(
                builder => builder
                    .WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:5001",
                        "http://localhost:5000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
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
