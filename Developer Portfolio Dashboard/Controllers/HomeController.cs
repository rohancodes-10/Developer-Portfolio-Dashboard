using Developer_Portfolio_Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Developer_Portfolio_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
