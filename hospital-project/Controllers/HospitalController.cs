using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hospital_project.Data;
using hospital_project.Models;
using hospital_project.Interfaces;

namespace hospital_project.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalRepository _hospitalRepository;
        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Hospital> hospitals = await _hospitalRepository.GetAll();
            return View(hospitals);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Hospital hospital = await _hospitalRepository.GetByIdAsync(id);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return View(hospital);
            }
            _hospitalRepository.Add(hospital);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Hospital hospital = await _hospitalRepository.GetByIdAsync(id);
            return View(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return View(hospital);
            }
            _hospitalRepository.Update(hospital);
            return RedirectToAction("Index");
        }
    }
}
