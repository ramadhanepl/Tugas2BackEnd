using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            var model = await _student.GetAll();
            /*var result = await _student.GetAll();
            string strResult = string.Empty;
            foreach (var result in results)
            {
                strResult += result.FirstMidName + "\n";
            }
            return Content(strResult);*/
            return View(model);
        }
    }
}
