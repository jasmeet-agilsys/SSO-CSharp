using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Collections.Generic;

public static class Config
{
    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client1",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets =
                {
                    new Duende.IdentityServer.Models.Secret("secret".Sha256())
                },
                RedirectUris = { "https://localhost:5001/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },
                AllowedScopes = { "openid", "profile", "api1" }
            },
            new Client
            {
                ClientId = "client2",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets =
                {
                    new Duende.IdentityServer.Models.Secret("secret".Sha256())
                },
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowedScopes = { "openid", "profile", "api1" }
            }
        };

    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

    public static List<TestUser> GetUsers() =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "password"
            }
        };
}
