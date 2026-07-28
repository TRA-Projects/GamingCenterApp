using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Visitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string VisitorName { get; set; } = string.Empty;

        [Required]
        [MaxLength(9)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        // One Visitor can write many Reviews
        public List<Review> Reviews { get; set; } = new List<Review>();

        // One Visitor can have many Bookings
        public List<Booking> bookings { get; set; } = new List<Booking>();
    }
}