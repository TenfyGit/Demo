using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace ThirdPartyConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1、访问认证中心获取token
            HttpClient httpClient= new HttpClient();
            #region 客户端模式
            //var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest() { 
            //    Address = "http://localhost:5000/connect/token",
            //    ClientId = "ThirdPartyClient",
            //    ClientSecret = "ThirdPartySecret",
            //    GrantType = GrantTypes.ClientCredentials
            //});
            #endregion
            #region 密码模式
            var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "ThirdPartyClient",
                ClientSecret = "ThirdPartySecret",
                GrantType = GrantTypes.Password,
                UserName = "tenfy",
                Password = "123456"
            });
            #endregion
            if (tokenResponse.IsError)
            {
                Console.WriteLine($"获取token失败，返回信息：{tokenResponse.ErrorDescription}");
            }
            else
            {
                Console.WriteLine(tokenResponse.AccessToken);
                //拿token访问api资源
                httpClient.SetBearerToken(tokenResponse.AccessToken);
                var response = await httpClient.GetAsync("http://localhost:5001/api/Values");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"获取api资源成功，返回信息：" + response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Console.WriteLine($"获取api资源失败，返回信息：" + response.Content.ReadAsStringAsync().Result);
                }
            }
            Console.ReadKey();
        }
    }
}
