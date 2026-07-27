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


        [Required(ErrorMessage = "Competition name is required")]
        [MaxLength(100, ErrorMessage = "Competition name cannot exceed 100 characters")]
        public string CompetitionName { get; set; } 


        [Required(ErrorMessage = "Start date is required")]
       
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "End date is required")]
       
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Players number is required")]
        [Range(2, 100, ErrorMessage = "Players number must be between 2 and 100")]
        public int PlayersNo { get; set; }


        [Required(ErrorMessage = "Competition status is required")]
        [MaxLength(50, ErrorMessage = "Competition status cannot exceed 50 characters")]
        public string CompetitionStatus { get; set; } = "Upcoming"; //Ongoing, Completed, Cancelled


        [Required(ErrorMessage = "Devices name is required")]
        [MaxLength(100, ErrorMessage = "Devices name cannot exceed 100 characters")]
        public string DevicesName { get; set; }

        // Foreign Key
        [Required]
        [ForeignKey("Room ")]
        public int RoomId { get; set; } 
        
       
        public virtual Room Room { get; set; }

    }
}
