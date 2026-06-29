using Microsoft.AspNetCore.Mvc;

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

            var url=$"https://github.com/login/oauth/authoraize"+
                $"?client_id={ClientId}" +
                $"&redirect_uri={RedirectUri}" +
                $"&Scope={scope}";
            return Redirect(url);
        }
    }
}
