
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //system generated
        public int paymentId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal amount { get; set; }               // calculated from booking

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }          // from list -"Cash"| "Credit Card" | "Debit Card"

        [Required]
        [MaxLength(30)]
        public string paymentStatus { get; set; } = "Pending"; // default value - "Pending" | "Paid" | " Failed"




        // foreign key - every payment belongs to exactly one booking 

        [Required]                 // from list - selected booking 
        [ForeignKey("Booking")]
        public int bookingId { get; set; }

        public virtual Booking Booking { get; set; }      // navigation property 








    }
}
