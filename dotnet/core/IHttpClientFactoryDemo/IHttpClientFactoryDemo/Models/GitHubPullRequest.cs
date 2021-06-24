using System.Text.Json.Serialization;

namespace IHttpClientFactoryDemo.Models
{
    public class GitHubPullRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
