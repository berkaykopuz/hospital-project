using hospital_project.Interfaces;
using hospital_project.Models;
using hospital_project.Repository;
using hospital_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hospital_project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClinicController : Controller
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IHospitalClinicRepository _hospitalClinicRepository;

        public ClinicController(IClinicRepository clinicRepository, IHospitalRepository hospitalRepository, 
            IHospitalClinicRepository hospitalClinicRepository)
        {
            _clinicRepository = clinicRepository;
            _hospitalRepository = hospitalRepository;
            _hospitalClinicRepository = hospitalClinicRepository;
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
        public async Task<IActionResult> Create(Clinic clinic)
        {
            if (!ModelState.IsValid)
            {
                return View(clinic);
            }
            _clinicRepository.Add(clinic);
            return RedirectToAction("Index");
        }

        
        public IActionResult ClinicHospitalMatch()
        {
            var clinicVM = new ClinicViewModel();

            clinicVM.Hospitals = _hospitalRepository.GetAllHospitals();
            clinicVM.Clinics = _clinicRepository.GetAllClinics();

            return View(clinicVM);
        }

        [HttpPost]
        public async Task<IActionResult> ClinicHospitalMatch(ClinicViewModel clinicVM)
        {
            if(ModelState.IsValid)
            {
                Clinic clinic = _clinicRepository.GetClinicById(clinicVM.SelectedClinicId);
                Hospital hospital = _hospitalRepository.GetHospitalById(clinicVM.SelectedHospitalId);

                if (clinic == null || hospital == null)
                {
                    return NotFound();
                }


                if (clinic.HospitalClinics.Any(hc => hc.HospitalId == hospital.Id))
                {
                    return Conflict("Hospital is already associated with the clinic.");
                }

                HospitalClinic hospitalClinic = new HospitalClinic
                {
                    ClinicId = clinic.Id,
                    HospitalId = hospital.Id
                };

                _hospitalClinicRepository.Add(hospitalClinic);
            }

            return View(clinicVM);
        }
    }
}
