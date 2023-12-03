using hospital_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace hospital_project.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save(Appointment appointment)
        {
            

            if(appointment != null)
            {
                DateTime date = appointment.Date;
                DateTime time = appointment.Time;

                
            }


            return View(appointment);
        }
    }
}
