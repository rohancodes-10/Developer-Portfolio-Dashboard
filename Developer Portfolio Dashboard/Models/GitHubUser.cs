using System.Text.Json.Serialization;
namespace Developer_Portfolio_Dashboard.Models
{
    public class GitHubUser
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("login")]
        public string? Login { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("following")]
        public int Following { get; set; }

        [JsonPropertyName("public_repos")]
        public int PublicRepos { get; set; }
    }
}
