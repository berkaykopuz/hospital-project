using hospital_project.Models;

namespace hospital_project.Interfaces
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAll();
        public List<Hospital> GetAllHospitals();
        Task<Hospital> GetByIdAsync(int id);
        bool Add(Hospital hospital);
        bool Update(Hospital hospital);
        bool Delete(Hospital hospital);
        bool Save();
        public Hospital GetHospitalById(int hospitalId);
    }
}
