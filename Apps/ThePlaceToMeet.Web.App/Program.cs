using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ThePlaceToMeet
{
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

// To generate identity pages in Areas/Identity:
// dotnet aspnet-codegenerator identity -dc ThePlaceToMeet.Infrastructure.RepositoryDbContext