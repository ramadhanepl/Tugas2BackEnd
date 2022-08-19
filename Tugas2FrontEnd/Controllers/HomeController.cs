using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            /*
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
            {
                HttpContext.Session.SetString($"token", "Bearer  ");
            }
            */
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}