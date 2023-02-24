using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using ThePlaceToMeet.Infrastructure.Repositories;
using ThePlaceToMeet.Filters;
using ThePlaceToMeet.Infrastructure;
using ThePlaceToMeet.Contracts.Interfaces;
using ThePlaceToMeet.Web.App.AutoMapper;
using System.Collections.Generic;
using System;

namespace ThePlaceToMeet
{

    public class Startup 
    {
        private IServiceCollection _services;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        private bool InDocker { get { return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true"; } }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            _services = services;

            System.Type[] profiles = { typeof(CateringProfile), typeof(KlantProfile), typeof(KortingProfile), typeof(ReservatieProfile), typeof(VergaderruimteProfile) };
            _services.AddAutoMapper(profiles);

            var dbConnection = Configuration.GetConnectionString("DefaultConnection");
            if(InDocker)
            {
                dbConnection += "Docker";
            }
            // Register EF before repositories...
            _services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(dbConnection));
            _services.AddDefaultIdentity<Infrastructure.DTO.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<RepositoryDbContext>();

            _services.AddScoped<IMeetingRoomRepository, MeetingRoomRepository>();
            _services.AddScoped<ICustomerRepository, CustomerRepository>();
            _services.AddScoped<ICateringRepository, CateringRepository>();
            _services.AddScoped<IDiscountRepository, DiscountRepository>();
            _services.AddScoped<ApplicationDataInitializer>();
            _services.AddScoped<KlantFilter>();

            _services.AddAuthorization(options =>
            {
                options.AddPolicy("Klant", policy => policy.RequireClaim(ClaimTypes.Role, "klant"));
            });    
            
            _services.AddControllersWithViews().AddRazorRuntimeCompilation();
            _services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDataInitializer initializer) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                _services.AddDatabaseDeveloperPageExceptionFilter();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var headers = new Dictionary<string, string>() {
                {"X-Frame-Options", "DENY" },
                {"X-Xss-Protection", "1; mode=block"},
                {"X-Content-Type-Options", "nosniff"},
                {"Referrer-Policy", "no-referrer"},
                {"X-Permitted-Cross-Domain-Policies", "none"},
                {"Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()"},
                {"Content-Security-Policy", "default-src 'self'"}
            };
            // Middleware to control headers...
            app.Use(async (context, next) =>
            {
                foreach (var keyvalue in headers)
                {
                    if (!context.Response.Headers.ContainsKey(keyvalue.Key))
                    {
                        context.Response.Headers.Add(keyvalue.Key, keyvalue.Value);
                    }
                }
                await next(context);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            initializer.InitializeData().Wait();
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App