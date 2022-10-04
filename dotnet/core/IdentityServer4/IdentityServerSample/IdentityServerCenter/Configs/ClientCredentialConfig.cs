using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerCenter.Configs
{
    /// <summary>
    /// 客户端认证配置
    /// </summary>
    public class ClientCredentialConfig
    {
        /// <summary>
        /// 获取api资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>() {
                new ApiResource("ResourceApi","api资源"){
                    Scopes = new List<string>(){
                        "scope1"
                    }
                }
            };
        }
        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>() {
                new Client(){
                    ClientId = "ThirdPartyClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("ThirdPartySecret".Sha256())
                    },
                    AllowedScopes = new List<string> {
                        "scope1"
                    }
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>() {
                new ApiScope("scope1")
            };
        }
    }
}
