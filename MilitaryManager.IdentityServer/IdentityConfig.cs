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
					AllowedGrantTypes = GrantTypes.Code,
					AllowAccessTokensViaBrowser = true,

					RequireConsent = false,
					RequireClientSecret = false,

					RedirectUris =           { $"{hostname}/SignInCallback", $"{hostname}/SilentSignInCallback" },
					PostLogoutRedirectUris = { $"{hostname}/SignOutCallback" },
					AllowedCorsOrigins = { hostname },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						JwtClaimTypes.Role,
						"api1"
					}
				}
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
					},
					Scopes = { "api1" }
				}
			};

		}

		public static IEnumerable<ApiScope> GetApiScopes()
        {
			return new List<ApiScope> 
			{ 
				new ApiScope("api1", "API 1") 
			};
		}
	}
}
