#if ApiConventions

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net.Sockets;
using System.Net;
using ThePlaceToMeet.Contracts.Interfaces;
using ThePlaceToMeet.Infrastructure;
using ThePlaceToMeet.Infrastructure.Repositories;
using ThePlaceToMeet.WebApi.Hubs;
/*
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
*/

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
#endif

namespace ThePlaceToMeet.WebApi
{
    /*
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize =
              context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
              || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme {Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"}
                        }
                    ] = new[] {"test.api"}
                }
            };

            }
        }
    }
    */

    public class Program
    {
        public static string GetLocalIPAddress()
        {
            string ipName = null;
            var hostName = Dns.GetHostName();
            Console.WriteLine("Host name: " + hostName);
            var host = Dns.GetHostEntry(hostName);
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipName = ip.ToString();
                    Console.WriteLine("Found IP: " + ipName);
                }
            }
            if(!string.IsNullOrEmpty(ipName))
            {
                return ipName;
            }
            throw new Exception("No network adapters with an IPv4 address.");
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel()
                // .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseUrls("http://*:5204,https://*.7045");

            builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Version", "1.0.0")
                .ReadFrom.Configuration(ctx.Configuration));
                                 
            var sqlServer = builder.Configuration.GetValue<bool>("App:SQLServer");
            var hsTs = builder.Configuration.GetValue<bool>("App:HsTs");
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (!sqlServer)
            {
                connectionString = builder.Configuration.GetConnectionString("DefaultMySQLConnection");

                var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

                // Add services to the container.
                builder.Services.AddDbContext<RepositoryDbContext>(options =>
                    options.UseMySql(connectionString, serverVersion)
                    .UseLoggerFactory(LoggerFactory.Create(b => b
                        .AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                );
            }
            else
            {
                // Add services to the container.
                builder.Services.AddDbContext<RepositoryDbContext>(options =>
                 options.UseSqlServer(connectionString, b => b.EnableRetryOnFailure()));
            }

            // SignalR:
            builder.Services.AddSignalR(o =>
            {                
                o.EnableDetailedErrors = true;
            });

            var corsOrigins = builder.Configuration["App:CorsOrigins"];
            var corsActive = builder.Configuration.GetValue<bool>("App:CorsActive");
            // var corsActive =  corsActiveString.Equals("true") ? true : false;
            if (corsActive)
            {
                // Adding CORS Policy
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowOrigin", builder =>
                    {
                        /*
                        var origins = corsOrigins?.Split(",", StringSplitOptions.RemoveEmptyEntries)
                            //.Select(o => o.RemovePostFix("/"))
                            .ToArray();
                        if (origins != null)
                            builder.WithOrigins(origins);
                        else
                        */
                            builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                       //.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                       //.WithHeaders("authorization", "accept", "content-type", "origin")
                       //.AllowCredentials()
                       .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
                    });
                });
            }

            /*
            // Identity Server:
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.Authority = "https://localhost:5005";
                    opt.Audience = "test.api";                   
                });
            */
            builder.Services.AddScoped<IMeetingRoomRepository, VergaderruimteRepository>();
            builder.Services.AddScoped<ICustomerRepository, KlantRepository>();
            builder.Services.AddScoped<ICateringRepository, CateringRepository>();
            builder.Services.AddScoped<IDiscountRepository, KortingRepository>();
           
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(/* options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5005/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5005/connect/token"),                            
                            Scopes = new Dictionary<string, string>
                            {
                                {"test.api", "ThePlaceToMeet API V1"}
                            }
                        }
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            }*/);
            
            var app = builder.Build();            

            app.Logger.LogInformation("ThePlaceToMeet API is starting...");
            app.Logger.LogInformation("Connection string: " + connectionString);
            app.Logger.LogInformation("Local IP: " + GetLocalIPAddress());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.Logger.LogInformation("Development mode: setting up swagger...");
                app.UseSwagger();
                app.UseSwaggerUI(
                /* options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ThePlaceToMeet API V1");

                    options.OAuthAppName("ThePlaceToMeet API - Swagger");
                    options.OAuthClientId("interactive.public");
                    options.OAuthClientSecret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0");
                    options.OAuthScopeSeparator(" ");
                    options.OAuth2RedirectUrl("https://localhost:5005/Account/Login");                        
                    //options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                    options.OAuthUsePkce();
                }*/
                );
            }
            else if(hsTs)
            {
                Console.WriteLine("Release: HSTS (https)");
                app.UseHsts(); // https
            }
            

            app.Logger.LogInformation("Setting up headers...");
            UseHeadersMiddleware(app);

            // to check header locally, use PowerShell command:
            // (invoke-webrequest https://localhost:7045/MeetingRoom).headers

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();


            /*
            // For Identity Server:
            app.UseAuthentication();
            */
            app.UseAuthorization();

            // SignalR:
            app.MapHub<ChatHub>("/chathub");

            app.MapControllers();

            app.UseCors("AllowOrigin");

            app.Run();
        }

        private static void UseHeadersMiddleware(WebApplication app)
        {
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
        }
    }
}
// TODO: as Administrator?
// dotnet dev-certs https –-trust