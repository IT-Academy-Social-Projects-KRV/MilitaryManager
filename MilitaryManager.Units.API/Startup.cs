using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Net;

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
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(opt =>
           { 
               opt.RequireHttpsMetadata = false;
               
               //opt.Authority = $"https://{{Configuration.GetConnectionString('DefaultConnection')}}:5007";
               //TODO: move link to appsettings
               opt.Authority = "http://militarymanager.identity.server";
               //opt.Authority = "http://localhost:5006";
               opt.TokenValidationParameters = new TokenValidationParameters
               {
                   //TODO: IT IS NOT SECURE
                   ValidateAudience = false,
                   ValidateIssuer = false,
               };
               //opt.TokenValidationParameters = new TokenValidationParameters
               //{
               //    ValidateIssuerSigningKey = true,
               //    ValidateLifetime = true,
               //    ValidateIssuer = true,
               //    ValidIssuer = "api1",  
               //    ValidateAudience = true
               //};
               //opt.Audience = "api1";
               //opt.Configuration = new OpenIdConnectConfiguration();

           });

            services.AddAuthorization();

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

            app.UseCors(
                builder => builder
                    .AllowAnyOrigin()
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
