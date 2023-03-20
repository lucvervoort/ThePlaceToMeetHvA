using Duende.IdentityServer.Services;
using ThePlaceToMeet.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThePlaceToMeet.IdentityService.Pages.Register;

[SecurityHeaders]
[AllowAnonymous]
public class AlreadyRegistered : PageModel
{
    private readonly IIdentityServerInteractionService _interactionService;
        
    public RegisterViewModel View { get; set; }

    public AlreadyRegistered(IIdentityServerInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task OnGet(ApplicationUser user)
    {
        View = new RegisterViewModel
        {
            AutomaticRedirectAfterRegistration = RegisterOptions.AutomaticRedirectAfterRegistration,
            PostRegisterRedirectUri = "/Account/Login",
            ClientName = user.UserName
        };
    }
}