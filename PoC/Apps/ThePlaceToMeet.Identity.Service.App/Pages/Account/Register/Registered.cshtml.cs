using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThePlaceToMeet.IdentityService.Pages.Register;

[SecurityHeaders]
[AllowAnonymous]
public class Registered : PageModel
{
    private readonly IIdentityServerInteractionService _interactionService;
        
    public RegisterViewModel View { get; set; }

    public Registered(IIdentityServerInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task OnGet(InputModel input)
    {
        View = new RegisterViewModel
        {
            AutomaticRedirectAfterRegistration = RegisterOptions.AutomaticRedirectAfterRegistration,
            PostRegisterRedirectUri = "~/Account/Login",
            ClientName = String.IsNullOrEmpty(input?.UserName) ? input?.UserName : ""
        };
    }
}