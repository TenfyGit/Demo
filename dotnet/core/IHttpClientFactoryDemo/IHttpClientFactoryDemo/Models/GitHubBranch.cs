using System.Text.Json.Serialization;

namespace IHttpClientFactoryDemo.Models
{
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
