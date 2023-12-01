using Microsoft.AspNetCore.Identity;

namespace hospital_project.Models
{
    public class Citizen : IdentityUser
    {
        public ICollection<Appointment> Appointments { get; set; }
    }
}
