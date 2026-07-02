using System.Text.Json.Serialization;

namespace Developer_Portfolio_Dashboard.Models
{
    public class Repo
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("html_url")]
        public string? Url { get; set; }

        [JsonPropertyName("stargazers_count")]
        public int Stars { get; set; }

        [JsonPropertyName("forks_count")]
        public int Forks { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("visibility")]
        public string? Visibility { get; set; }
    }
}
