using Microsoft.AspNetCore.Mvc;
using Tugas2FrontEnd.Models;
using Tugas2FrontEnd.Services;

namespace Tugas2FrontEnd.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                var result = await _user.Registration(user);
                //ViewData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Berhasil menambahkan data samurai {result.Name}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-primary' role='alert'>{ex.Message}</ div > ";
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        } 

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var result = await _user.Login(user);
                
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
                {
                    HttpContext.Session.SetString("token", $"Bearer {result.Token}");
                }
                
                //TempData["pesan"] = $"{result.Token}";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Error: {ex.Message}</div>";
                return View();
            }
        }
    }
}
