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
					ClientId = "angular",
					ClientName = "Angular SPA",
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
						"unitsAPI",
						"attachmentsAPI"
					}
				}
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("unitsAPI")
				{
					UserClaims =
					{
						JwtClaimTypes.Name,
						JwtClaimTypes.Email,
						JwtClaimTypes.Role
					},
					Scopes = { "unitsAPI" }
				},
				new ApiResource("attachmentsAPI")
				{
					UserClaims =
					{
						JwtClaimTypes.Name,
						JwtClaimTypes.Email,
						JwtClaimTypes.Role
					},
					Scopes = { "attachmentsAPI" }
				}
			};

		}

		public static IEnumerable<ApiScope> GetApiScopes()
        {
			return new List<ApiScope> 
			{ 
				new ApiScope("unitsAPI", "Units API"),
				new ApiScope("attachmentsAPI", "Attachments API")
			};
		}
	}
}
