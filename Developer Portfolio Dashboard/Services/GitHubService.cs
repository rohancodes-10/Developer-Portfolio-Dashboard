using Developer_Portfolio_Dashboard.Models;

namespace Developer_Portfolio_Dashboard.Services
{
    public class GitHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GitHubUser?> GetUserAsync(string accessToken)
        {
            var client = _httpClientFactory.CreateClient("GitHub");
            Console.WriteLine($"BaseAddress: {client.BaseAddress}");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("user");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<GitHubUser>();
        }

        public async Task<List<Repo>> GetReposAsync(string accessToken)
        {
            var client = _httpClientFactory.CreateClient("GitHub");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("user/repos?sort=updated&per_page=10");

            if (!response.IsSuccessStatusCode)
                return new List<Repo>();

            return await response.Content.ReadFromJsonAsync<List<Repo>>() ?? new List<Repo>();
        }
    }
}