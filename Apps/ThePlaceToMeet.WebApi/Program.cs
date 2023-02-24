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
using Microsoft.AspNetCore.Server.Kestrel.Https;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
#endif

namespace ThePlaceToMeet.WebApi
{
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

            var corsOrigins = builder.Configuration["App:CorsOrigins"];
            var corsActive = builder.Configuration.GetValue<bool>("App:CorsActive");
            var letsEncryptActive = builder.Configuration.GetValue<bool>("App:LetsEncrypt");

            // netstat -plnt
            // to enable listening on 0.0.0.0 instead of 127.0.0.1: see launchSettings.json

            // https://adamtheautomator.com/cloudflare-ssl/
            // https://www.hanselman.com/blog/ASPNETCoreLetsEncryptAndCloudflareSSLWithACustomDomain.aspx

            if (letsEncryptActive)
            {
                Console.WriteLine("LetsEncrypt is active");
                // This example shows how to configure Kestrel's client certificate requirements along with
                // enabling Lettuce Encrypt's certificate automation.
                {
                    builder.WebHost.UseKestrel(kestrel =>
                    {
                        var appServices = kestrel.ApplicationServices;
                        kestrel.ConfigureHttpsDefaults(h =>
                        {
                            h.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                            h.UseLettuceEncrypt(appServices);
                        });
                    });
                }

                /*
                // This example shows how to configure Kestrel's address/port binding along with
                // enabling Lettuce Encrypt's certificate automation.
                {
                    builder.WebHost.PreferHostingUrls(false);
                    builder.WebHost.UseKestrel(kestrel =>
                    {                        
                        var appServices = kestrel.ApplicationServices;
                        kestrel.Listen(IPAddress.Any, 7045,
                            o =>
                                o.UseHttps(h => h.UseLettuceEncrypt(appServices)));
                    });
                }
                */
            }
            else
            {
                Console.WriteLine("LetsEncrypt not active");
            }

            builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Version", "1.0.0")
                .ReadFrom.Configuration(ctx.Configuration));
                                 
            var sqlServer = builder.Configuration.GetValue<bool>("App:SQLServer");
            var hsTs = builder.Configuration.GetValue<bool>("App:HsTs");
            var docker = builder.Configuration.GetValue<bool>("App:Docker");
            var connectionStringName = "DefaultConnection";
            var connectionString = "";
            if (!sqlServer)
            {
                connectionStringName = "DefaultMySQLConnection";
                if (docker) connectionStringName += "Docker";
                connectionString = builder.Configuration.GetConnectionString(connectionStringName);

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
                if (docker) connectionStringName += "Docker";
                connectionString = builder.Configuration.GetConnectionString(connectionStringName);
                // Add services to the container.
                builder.Services.AddDbContext<RepositoryDbContext>(options =>
                 options.UseSqlServer(connectionString, b => b.EnableRetryOnFailure()));
            }

            if (letsEncryptActive)
            {
                builder.Services.AddLettuceEncrypt();
            }

            // SignalR:
            builder.Services.AddSignalR(o =>
            {                
                o.EnableDetailedErrors = true;
            });

            // var corsActive =  corsActiveString.Equals("true") ? true : false;
            if (corsActive)
            {
                Console.WriteLine("Cors active");
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

            builder.Services.AddScoped<IMeetingRoomRepository, VergaderruimteRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ICustomerRepository, KlantRepository>();
            builder.Services.AddScoped<ICateringRepository, CateringRepository>();
            builder.Services.AddScoped<IDiscountRepository, KortingRepository>();
           
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();            

            app.Logger.LogInformation("ThePlaceToMeet API is starting...");
            app.Logger.LogInformation("Connection string: " + connectionString);
            app.Logger.LogInformation("Local IP: " + GetLocalIPAddress());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.Logger.LogInformation("Development mode: setting up swagger...");
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else if(hsTs)
            {
                app.Logger.LogInformation("Release: HSTS (https)");
                app.UseHsts(); // https
            }
            else if(app.Environment.IsProduction())
            {
                app.Logger.LogInformation("Production mode");
            }
            

            app.Logger.LogInformation("Setting up headers...");
            UseHeadersMiddleware(app);

            // to check header locally, use PowerShell command:
            // (invoke-webrequest https://localhost:7045/MeetingRoom).headers

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

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
