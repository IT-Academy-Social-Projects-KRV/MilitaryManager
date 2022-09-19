using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

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

            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
           });*/

            /*services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });*/

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://militarymanager.identity.server";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //TODO: IT IS NOT SECURE
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var cookie = context.Request.Cookies["oidc.user%3Ahttps%3A%2F%2Flocalhost%3A5007%3Ajs"];
                            var data = (JObject)JsonConvert.DeserializeObject(cookie);
                            string access_token = data["access_token"].Value<string>();
                            context.Token = access_token;
                            return Task.CompletedTask;
                        }
                    };
                });

            // Configure cookie authentication.
            /* services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options => {
                 //options.Cookie.Name = "idsrv.session";
                 //options.Cookie.SameSite = SameSiteMode.Strict;
                 //options.Cookie.HttpOnly = true;
                 //options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                 //options.Cookie.IsEssential = true;
                 //options.SlidingExpiration = true;
                 //options.Cookie.Name = ".AspNetCore.Identity.Application";
                 options.Cookie.SameSite = SameSiteMode.None;
                 options.Events = new CookieAuthenticationEvents
                 {
                     OnRedirectToLogin = redirectContext =>
                     {
                         redirectContext.HttpContext.Response.StatusCode = 401;
                         return Task.CompletedTask;
                     }
                 };
             });*/

            /*services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://militarymanager.identity.server";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                    options.SupportedTokens = SupportedTokens.Reference;
                    //options.ApiSecret = appConfiguration.IdentityServerSettings.ApiSecret;
                }).AddCookie("AuthCookie", options =>
                {
                    //options.ExpireTimeSpan = ...;
                });*/
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
                    .WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:5001",
                        "http://localhost:5000")
                    //.AllowAnyOrigin()
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
