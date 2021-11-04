// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DeeFlat.IS4.WebHost
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
              new ApiResource("dictionary-api", "API Test dictionary")
           };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("dictionary-api"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "spa.client",
                    ClientName = "React WEB Application",

                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:3000", "http://localhost:3000/authentication/callback","http://localhost:3000/authentication/silent_callback"},
                    PostLogoutRedirectUris ={"http://localhost:3000"},
                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes = {  "openid", "profile", "scope2", "scope1", "api1", "test-api", "dictionary-api" }
                },
                new Client
                {
                    ClientId = "spa.client1",
                    ClientName = "React WEB Application",

                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:3000", "http://localhost:3000/authentication/callback"},
                    PostLogoutRedirectUris ={"http://localhost:3000"},
                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes = {  "openid", "profile", "scope2", "scope1", "api1", "test-api", "dictionary-api" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2", "scope1" }
                },
            };
    }
}