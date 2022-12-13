using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace GruppKniv.Services.IdentityAPI;
public static class StaticDetatiles
{
    public const string Admin = "Admin";
    public const string Customer = "Customer";

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> {
            new ApiScope("Magic", "Magic Server"),
            new ApiScope(name: "read",   displayName: "Read your data."),
            new ApiScope(name: "write",  displayName: "Write your data."),
            new ApiScope(name: "delete", displayName: "Delete your data.")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId="service.client",
                ClientSecrets= { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes={ "api1", "api2.readonly"}
            },
            new Client
            {
                ClientId="Magic",
                ClientSecrets= { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris={"https://localhost:7068/signin-oidc"},
                PostLogoutRedirectUris={"https://localhost:7068/signout-callback-oidc"},
                AllowedScopes=new List<string>
                {
                    "Magic",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    JwtClaimTypes.Role
                }
            },
        };
}
