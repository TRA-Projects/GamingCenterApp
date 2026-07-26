using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.CompetitionDTO
{
    public class CompetitionDTO
    {
        [Required(ErrorMessage = "Competition name is required")]
        [MaxLength(100)]
        public string CompetitionName { get; set; }


        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Players number is required")]
        [Range(2, 100)]
        public int PlayersNo { get; set; }


        [Required(ErrorMessage = "Devices name is required")]
        [MaxLength(100)]
        public string DevicesName { get; set; }


        [Required]
        public int RoomId { get; set; }

    }
}
