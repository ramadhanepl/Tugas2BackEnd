using Microsoft.AspNetCore.Mvc;
using Tugas2FrontEnd.Models;
using Tugas2FrontEnd.Services;

namespace Tugas2FrontEnd.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }

        public async Task<IActionResult> Index(String? name)
        {
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            string myToken = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
            {
                myToken = HttpContext.Session.GetString("token"); 
            }
            IEnumerable<Course> model;
            if (name == null)
            {
                model = await _course.GetAll(myToken);
            }
            else
            {
                model = await _course.GetByName(name, myToken);
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                var result = await _course.Insert(course);
                //TempData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Berhasil menambahkan data samurai {result.Name}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Error: {ex.Message}</div>";
                return View();
            }

        }
    }
}
