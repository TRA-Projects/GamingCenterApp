using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        public string VisitorName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}