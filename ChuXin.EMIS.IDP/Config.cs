using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ChuXin.EMIS.IDP
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new IdentityResource[]
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email()
			};
		}

		internal static List<TestUser> GetUsers()
		{
			return new List<TestUser>
			{
				new TestUser { SubjectId = "1", Username = "alice", Password = "alice",
					Claims =
					{
						new Claim(JwtClaimTypes.Name, "Alice Smith"),
						new Claim(JwtClaimTypes.Email, "AliceSmith@email.com")
					}
				},
				new TestUser { SubjectId = "11", Username = "bob", Password = "bob",
					Claims =
					{
						new Claim(JwtClaimTypes.Name, "Bob Smith"),
						new Claim(JwtClaimTypes.Email, "BobSmith@email.com")
					}
				}
			};
		}


		public static IEnumerable<ApiResource> GetApis()
		{
			return new ApiResource[]
			{
				new ApiResource("api1", "My API1")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
			
				// client credentials flow client
				new Client()
				{
					// ClientId 和 ClientName 后面使用界面管理
					ClientId = "client",
					//ClientName = "Client Credentials Client",

					AllowedGrantTypes = GrantTypes.ClientCredentials,

					ClientSecrets = { new Secret("secret".Sha256()) },

					AllowedScopes = { "api1" }
				},

				// implicit
				new Client()
				{
					ClientId = "react-spa-client",
					ClientName = "CHUXIN EMIS SYSTEM",
					ClientUri = "http://localhost:3000",

					AllowedGrantTypes = GrantTypes.Implicit,
					AllowAccessTokensViaBrowser = true,
					RequireConsent = false,
					AccessTokenLifetime = 60 * 5,

					RedirectUris = 
					{
						"http://localhost:3000/loading",
						"http://localhost:3000/silent-renew",
					},
					PostLogoutRedirectUris = { "http://localhost:3000/login" },
					AllowedCorsOrigins = { "http://localhost:3000" },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"api1"
					},
				}
			};
		}
	}
}
