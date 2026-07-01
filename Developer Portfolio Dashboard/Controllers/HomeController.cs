using Developer_Portfolio_Dashboard.Models;
using Developer_Portfolio_Dashboard.Services;
using Developer_Portfolio_Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Developer_Portfolio_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly GitHubService _gitHubService;
        public HomeController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("github_token");
            if (string.IsNullOrEmpty(token))
            {
                return View(new HomeViewModel());
            }
            var user = await _gitHubService.GetUserAsync(token);
            var repos = await _gitHubService.GetReposAsync(token);

            HomeViewModel Model = new HomeViewModel
            {
                user =user,
                Repos=repos
            };
            return View(Model);
        }
    }
}
