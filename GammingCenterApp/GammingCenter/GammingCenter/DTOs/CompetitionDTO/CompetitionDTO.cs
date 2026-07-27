using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.CompetitionDTO
{
    public class CompetitionInputDTO
    {

        [Required(ErrorMessage = "Competition name is required.")]
        [MaxLength(100, ErrorMessage = "Competition name cannot exceed 100 characters.")]
        public string CompetitionName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Number of players is required.")]
        [Range(2, 100, ErrorMessage = "Number of players must be between 2 and 100.")]
        public int PlayersNo { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        [MaxLength(100, ErrorMessage = "Device name cannot exceed 100 characters.")]
        public string DevicesName { get; set; }

        [Required(ErrorMessage = "Room Id is required.")]
        public int RoomId { get; set; }
    }

    public class CompetitionOutputDTO
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PlayersNo { get; set; }

        public string CompetitionStatus { get; set; }

        public string DevicesName { get; set; }

        public int RoomId { get; set; }
    }
}
