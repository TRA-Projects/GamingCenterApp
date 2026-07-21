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


        // Navigation Property
        // reverse navigation - one Visitor can write many Reviews
        public List<Review> Reviews { get; set; } = new List<Review>();


        public List<Booking> bookings { get; set; } = new List<Booking>();
    }
}
