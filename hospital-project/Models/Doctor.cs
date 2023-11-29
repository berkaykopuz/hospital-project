

using System.ComponentModel.DataAnnotations;

namespace hospital_project.Models
{
    public class Doctor
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name="Doktor Adı")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mail Adresi")]
        public string Email { get; set; }

        public Hospital Hospital { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
