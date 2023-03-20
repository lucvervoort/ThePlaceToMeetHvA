using System.Security.Claims;
using IdentityModel;
using ThePlaceToMeet.IdentityService.Data;
using ThePlaceToMeet.IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ThePlaceToMeet.IdentityService.App;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var peter = userMgr.FindByNameAsync("peter@hogent.be").Result;
            if (peter == null)
            {
                peter = new ApplicationUser
                {
                    UserName = "peter@hogent.be",
                    Email = "peter@hogent.be",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(peter, "$P@ssword1").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(peter, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "peter@hogent.be"),
                            new Claim(JwtClaimTypes.GivenName, "Peter"),
                            new Claim(JwtClaimTypes.FamilyName, "Claeyssens"),
                            new Claim(JwtClaimTypes.WebSite, "http://peter.com"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("Peter created");
            }
            else
            {
                Log.Debug("Peter already exists");
            }

            var bob = userMgr.FindByNameAsync("jan@gmail.com").Result;
            if (bob == null)
            {
                bob = new ApplicationUser
                {
                    UserName = "jan@gmail.com",
                    Email = "jan@gmail.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(bob, "$P@ssword1").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Jan Hoet"),
                            new Claim(JwtClaimTypes.GivenName, "Jan"),
                            new Claim(JwtClaimTypes.FamilyName, "Hoet"),
                            new Claim(JwtClaimTypes.WebSite, "http://jan.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("Jan created");
            }
            else
            {
                Log.Debug("Jan already exists");
            }
        }
    }
}
