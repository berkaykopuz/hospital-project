using hospital_project.Models;

namespace hospital_project.Interfaces
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> GetAll();
        public List<Clinic> GetAllClinics();
        Task<Clinic> GetByIdAsync(int id);
        bool Add(Clinic clinic);
        bool Update(Clinic clinic);
        bool Delete(Clinic clinic);
        bool Save();
        public Clinic GetClinicById(int clinicId);
    }
}
