using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GammingCenter.Models
{
    public class Visitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorId { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string VisitorName { get; set; } // user input

        [Required]
        [MaxLength(9)]
        public string PhoneNumber { get; set; } // user input

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } // user input

        [Required]
        [MaxLength(3)]
        public int Age { get; set; } // user input

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } // user input


    }
}
