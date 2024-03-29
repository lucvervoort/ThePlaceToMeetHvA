﻿using Duende.IdentityServer.Models;

namespace ThePlaceToMeet.IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("test.api"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            /*
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "test.api" }
            },
            */

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive.public",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                //RedirectUris = { "https://localhost:5005/signin-oidc" },
                RedirectUris = { "https://localhost:5005/Account/Login" },
                FrontChannelLogoutUri = "https://localhost:5005/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5005/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "test.api" }
            },
        };
}
