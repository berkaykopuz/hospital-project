

namespace hospital_project.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public ICollection<HospitalClinic> ?HospitalClinics { get; set; }
    }
}
