﻿using hospital_project.Data;
using hospital_project.Interfaces;
using hospital_project.Models;
using Microsoft.EntityFrameworkCore;

namespace hospital_project.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Clinic> GetAllClinics()
        {
            return _context.Clinics.ToList();
        }

        public bool Add(Clinic clinic)
        {
            _context.Add(clinic);
            return Save();
        }

        public bool Delete(Clinic clinic)
        {
            _context.Remove(clinic);
            return Save();
        }

        public async Task<IEnumerable<Clinic>> GetAll()
        {
            return await _context.Clinics.ToListAsync();
        }

        public async Task<Clinic> GetByIdAsync(int id)
        {
            return await _context.Clinics.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Clinic clinic)
        {
            _context.Update(clinic);
            return Save();
        }

        public Clinic GetClinicById(int clinicId)
        {
            return _context.Clinics.FirstOrDefault(c => c.Id == clinicId);
        }
    }
}
