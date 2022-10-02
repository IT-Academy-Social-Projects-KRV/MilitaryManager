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
            services.AddCustomServices();
            services.AddAutoMapper();
            services.AddRepositories();
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
