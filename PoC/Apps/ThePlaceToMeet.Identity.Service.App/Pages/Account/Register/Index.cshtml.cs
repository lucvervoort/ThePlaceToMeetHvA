using Duende.IdentityServer.Services;
using IdentityModel;
using ThePlaceToMeet.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.Security.Claims;

namespace ThePlaceToMeet.IdentityService.Pages.Register;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IEventService _events;

    public RegisterViewModel View { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public Index(UserManager<ApplicationUser> userManager, IIdentityServerInteractionService interaction, IEventService events)
    {
        _userManager = userManager;
        _interaction = interaction;
        _events = events;
    }

    public async Task<IActionResult> OnGet(string returnUrl)
    {
        await BuildModelAsync();

        var showRegistrationPrompt = RegisterOptions.ShowRegistrationPrompt;

        if (User?.Identity.IsAuthenticated == true)
        {
            // if the user is authenticated, then just show registered page
            showRegistrationPrompt = false;
        }

        if (showRegistrationPrompt == false)
        {
            // if the request for logout was properly authenticated from IdentityServer, then
            // we don't need to show the prompt and can just log the user out directly.
            return await OnPost();
        }

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (User?.Identity.IsAuthenticated != true)
        {
            var user = _userManager.FindByNameAsync(Input.UserName).Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    EmailConfirmed = true,
                };
                var result = _userManager.CreateAsync(user, Input.Password).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = _userManager.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Name, Input.Name),
                            new Claim(JwtClaimTypes.GivenName, Input.GivenName),
                            new Claim(JwtClaimTypes.FamilyName, Input.FamilyName),
                            new Claim(JwtClaimTypes.WebSite, Input.WebSite),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug(Input.UserName + " created");
                await BuildModelAsync();
                return RedirectToPage("/Account/Register/Registered", Input);
            }
            else
            {
                Log.Debug(Input.UserName + " already exists");
                await BuildModelAsync();
                return RedirectToPage("/Account/Register/AlreadyRegistered", user);
            }
        }
        await BuildModelAsync();
        return RedirectToPage("/Account/Register");
    }

    private async Task BuildModelAsync()
    {
        Input = new InputModel
        {
        };
    }
}