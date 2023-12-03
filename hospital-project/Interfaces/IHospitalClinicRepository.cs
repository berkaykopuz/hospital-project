using hospital_project.Models;

namespace hospital_project.Interfaces
{
    public interface IHospitalClinicRepository
    {
        public bool Add(HospitalClinic hc);
        public bool Save();
    }
}
