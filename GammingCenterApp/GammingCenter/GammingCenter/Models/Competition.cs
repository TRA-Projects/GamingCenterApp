using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    [Table("Competition")]
    public class Competition
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitionId { get; set; }


        [Required]
        [MaxLength(100)]
        public string CompetitionName { get; set; } 


        [Required]
       
        public DateTime StartDate { get; set; }


        [Required]
       
        public DateTime EndDate { get; set; }


        [Required]
        [Range(2, 100)]
        public int PlayersNo { get; set; }


        [Required]
        [MaxLength(50)]
        public string CompetitionStatus { get; set; } = "Upcoming"; //Ongoing, Completed, Cancelled


        [Required]
        [MaxLength(100)]
        public string DevicesName { get; set; }

        // Foreign Key
        [Required]
        [ForeignKey("Room ")]
        public int RoomId { get; set; } 
        
       
        public virtual Room Room { get; set; }


     

    }
}
