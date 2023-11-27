using hospital_project.Interfaces;
using hospital_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace hospital_project.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public  async Task<IActionResult> Index()
        {
            IEnumerable<Doctor> doctors = await _doctorRepository.GetAll();
            return View(doctors);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            return View(doctor);
        }
        
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            _doctorRepository.Add(doctor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            _doctorRepository.Update(doctor);
            return RedirectToAction("Index");
        }

    }
}
