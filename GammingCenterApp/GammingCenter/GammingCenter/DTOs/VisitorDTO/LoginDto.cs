using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.VisitorDTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
