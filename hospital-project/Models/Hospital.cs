

namespace hospital_project.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HospitalClinic> HospitalClinics { get; set; }
    }
}
