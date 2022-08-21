using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
	public class IdentityConfig
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResource("role", new []{ JwtClaimTypes.Role })
			};
		}
		

		public static IEnumerable<Client> GetClients(string hostname)
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "js",
					ClientName = "JavaScript Client",
					AllowedGrantTypes = GrantTypes.Implicit,
					AllowAccessTokensViaBrowser = true,

					RequireConsent = false,

					RedirectUris =           { $"{hostname}/SignInCallback", $"{hostname}/SilentSignInCallback" },
					PostLogoutRedirectUris = { $"{hostname}/" },
					AllowedCorsOrigins = { hostname },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						JwtClaimTypes.Role,
						"api1"
					}
				},
				//TODO: FIX
				//-------------FIX-----------------
				new Client
				{
					ClientId = "oidcClient",
					ClientName = "Example Client Application",
					ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
    
					AllowedGrantTypes = GrantTypes.Code,
					RedirectUris = new List<string> {"https://localhost:5007/signin-oidc"},
					AllowedScopes = new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						"api"
					},

					RequirePkce = true,
					AllowPlainTextPkce = false
				}
				//-------------FIX-----------------
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("api1")
				{
					UserClaims =
					{
						JwtClaimTypes.Name,
						JwtClaimTypes.Email,
						JwtClaimTypes.Role
					}
				}
			};

		}
	}
}
