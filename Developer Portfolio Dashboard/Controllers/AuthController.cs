using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Mvc;
using Developer_Portfolio_Dashboard.Models;

namespace Developer_Portfolio_Dashboard.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Login()
        {
            var ClientId = _config["GitHub:ClientId"];
            var RedirectUri = _config["GitHub:RedirectUri"];
            var scope = "read:user repo";

            var url = $"https://github.com/login/oauth/authorize" +
            $"?client_id={ClientId}" +
            $"&redirect_uri={RedirectUri}" +
            $"&scope={scope}";

            return Redirect(url);
        }
        public async Task<IActionResult> Callback(string code)
        {
            if(string.IsNullOrEmpty(code))
            {
                return RedirectToAction("index", "home");
            }
            var ClientId = _config["GitHub:ClientId"];
            var ClientSecret = _config["GitHub:ClientSecret"];
            var redirectUri = _config["GitHub:RedirectUri"];

            //exchanging code for access token
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await http.PostAsJsonAsync(
                "https://github.com/login/oauth/access_token",
                new
                {
                    client_id=ClientId,
                    client_secret=ClientSecret,
                    code=code,
                    redirect_uri=redirectUri
                });

            var result = await response.Content.ReadFromJsonAsync<GitHubTokenResponse>();

            if (result?.AccessToken == null)
            {
                return RedirectToAction("index", "home");
            }
            HttpContext.Session.SetString("github_token", result.AccessToken);
            return RedirectToAction("Dashboard", "home");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }

    }
}
