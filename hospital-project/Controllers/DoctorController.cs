using hospital_project.Interfaces;
using hospital_project.Models;
using hospital_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace hospital_project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHospitalRepository _hospitalRepository;

        public DoctorController(IDoctorRepository doctorRepository,IHospitalRepository hospitalRepository)
        {
            _doctorRepository = doctorRepository;
            _hospitalRepository = hospitalRepository;
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
        
        public  IActionResult Create() {
            var doctorVM = new DoctorViewModel(); 

            doctorVM.Hospitals = _hospitalRepository.GetAllHospitals();

            return View(doctorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorViewModel doctorVM)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = new Doctor
                {
                    Name = doctorVM.Name,
                    Email = doctorVM.Email,
                    Appointments = doctorVM.Appointments,
                    Hospital = _hospitalRepository.GetHospitalById(doctorVM.SelectedHospitalId)
                };

                _doctorRepository.Add(doctor);
                return RedirectToAction("Index");

            }
            return View(doctorVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);

            DoctorViewModel doctorVM = new DoctorViewModel();
            doctorVM.Name = doctor.Name;
            doctorVM.Email = doctor.Email;
            doctorVM.Hospitals = _hospitalRepository.GetAllHospitals();
            
            return View(doctorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DoctorViewModel doctorVM)
        {
            
            if (ModelState.IsValid)
            {
                Doctor doctor = _doctorRepository.GetDoctorById(doctorVM.Id);
           
                doctor.Name = doctorVM.Name;
                doctor.Email = doctorVM.Email;
                doctor.Hospital = _hospitalRepository.GetHospitalById(doctorVM.SelectedHospitalId);

                _doctorRepository.Update(doctor);

                return RedirectToAction("Index");
                
            }
            return View(doctorVM);
        }

    }
}
