using IHttpClientFactoryDemo.Models;
using IHttpClientFactoryDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHttpClientFactoryDemo.Controllers
{
    public class TypedClientController : Controller
    {
        private readonly GitHubService _gitHubService;
        public IEnumerable<GitHubIssue> LatestIssues { get; private set; }
        public TypedClientController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }
        public async Task<IEnumerable<GitHubIssue>> Get()
        {
            try
            {
                LatestIssues = await _gitHubService.GetAspNetDocsIssues();
            }
            catch (Exception)
            {
                LatestIssues = Array.Empty<GitHubIssue>();
            }
            return LatestIssues;
        }
    }
}
