using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServerCenter.Configs
{
    /// <summary>
    /// 密码认证配置
    /// </summary>
    public class PwdCredentialConfig
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
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new List<Secret>{ 
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
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>() { 
                new TestUser(){ 
                    SubjectId = "1",
                    Username = "tenfy",
                    Password = "123456"
                }
            };
        }
    }
}
