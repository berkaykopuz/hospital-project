using hospital_project.Models;
namespace hospital_project.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetByIdAsync(int id);
        bool Add(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Doctor doctor);
        bool Save();
        public Doctor GetDoctorById(int doctorId);
    }
}
