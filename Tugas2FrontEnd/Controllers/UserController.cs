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
                //TempData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Berhasil menambahkan data samurai {result.Name}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ViewData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Error: {ex.Message}</div>";
                return View();
            }
        }
    }
}
