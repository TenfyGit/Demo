using IHttpClientFactoryDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IHttpClientFactoryDemo.Controllers
{
    public class NamedClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IEnumerable<GitHubPullRequest> PullRequests { get; private set; }
        public NamedClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<GitHubPullRequest>> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "repos/dotnet/AspNetCore.Docs/pulls");
            var client = _httpClientFactory.CreateClient(MyConst.GitHub);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                PullRequests = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubPullRequest>>(responseStream);
            }
            else
            {
                PullRequests = Array.Empty<GitHubPullRequest>();
            }
            return PullRequests;
        }
    }
}
