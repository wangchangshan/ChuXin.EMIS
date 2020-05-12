using IdentityServer4.Models;
using System.Collections.Generic;

namespace ChuXin.EMIS.IDP
{
	public class Config
	{
		//http://localhost:5000/.well-known/openid-configuration

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new IdentityResource[]
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Address(),
				new IdentityResources.Phone(),
				new IdentityResources.Email()
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
			// client credentials flow client
			return new List<Client>
			{
				new Client()
				{
					// ClientId 和 ClientName 后面使用界面管理
					ClientId = "client",
					//ClientName = "Client Credentials Client",

					AllowedGrantTypes = GrantTypes.ClientCredentials,

					ClientSecrets = { new Secret("secret".Sha256()) },

					AllowedScopes = { "api1" }
				}
			};
		}
	}
}
