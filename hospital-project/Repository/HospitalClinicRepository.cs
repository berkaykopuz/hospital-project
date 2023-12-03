using hospital_project.Data;
using hospital_project.Interfaces;
using hospital_project.Models;
using Microsoft.EntityFrameworkCore;

namespace hospital_project.Repository
{
    public class HospitalClinicRepository : IHospitalClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public HospitalClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(HospitalClinic hc)
        {
            _context.Add(hc);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
