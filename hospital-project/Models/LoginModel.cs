using System.ComponentModel.DataAnnotations;

namespace hospital_project.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        private string? _returnUrl;
        public string? ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                {
                    return "/";
                }
                else
                {
                    return _returnUrl;
                }
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}
