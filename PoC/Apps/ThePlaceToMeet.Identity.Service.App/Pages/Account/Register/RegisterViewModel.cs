
// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


namespace ThePlaceToMeet.IdentityService.Pages.Register;

public class RegisterViewModel
{
    public string PostRegisterRedirectUri { get; set; }
    public string ClientName { get; set; }
    public bool AutomaticRedirectAfterRegistration { get; set; }
}