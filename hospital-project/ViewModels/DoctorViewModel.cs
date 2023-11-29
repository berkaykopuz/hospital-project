using hospital_project.Models;
using System.ComponentModel.DataAnnotations;

namespace hospital_project.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Doctor Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        public int SelectedHospitalId { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public List<Hospital> Hospitals { get; set; } = new List<Hospital>();
    }
}
