using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.VisitorDTO
{
    public class UpdateVisitorDto
    {
        [Required(ErrorMessage = "Visitor name is required.")]
        [MaxLength(100)]
        public string VisitorName { get; set; } 


        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(9)]
        public string PhoneNumber { get; set; } 


        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        [MaxLength(10)]
        public string Gender { get; set; } 
    }
}
