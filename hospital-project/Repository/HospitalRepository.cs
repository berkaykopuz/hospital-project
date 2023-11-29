using hospital_project.Data;
using hospital_project.Interfaces;
using hospital_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace hospital_project.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _context;
        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Hospital> GetAllHospitals()
        {
            return _context.Hospitals.ToList();
        }

        public bool Add(Hospital hospital)
        {
            _context.Add(hospital);
            return Save();
        }

        public bool Delete(Hospital hospital)
        {
            _context.Remove(hospital);
            return Save();
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            return await _context.Hospitals.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Hospital hospital)
        {
            _context.Update(hospital);
            return Save();
        }
    }
}
