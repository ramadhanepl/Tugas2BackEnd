using Microsoft.AspNetCore.Mvc;
using Tugas2FrontEnd.Models;
using Tugas2FrontEnd.Services;

namespace Tugas2FrontEnd.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }
        public async Task<IActionResult> Index(String? name)
        {
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            IEnumerable<Student> model;
            if (name == null)
            {
                model = await _student.GetAll();
            }
            else
            {
                model = await _student.GetByName(name);
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                var result = await _student.Insert(student);
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
