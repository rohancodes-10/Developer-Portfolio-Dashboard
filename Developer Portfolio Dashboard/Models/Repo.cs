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

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}
