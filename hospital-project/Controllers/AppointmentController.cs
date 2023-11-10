using Microsoft.AspNetCore.Mvc;

namespace hospital_project.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
