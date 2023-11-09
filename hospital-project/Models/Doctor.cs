

namespace hospital_project.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }



        public ICollection<Appointment> Appointments { get; set; }


    }
}
