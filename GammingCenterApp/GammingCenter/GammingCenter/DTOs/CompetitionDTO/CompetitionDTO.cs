using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.CompetitionDTO
{
    public class CompetitionInputDTO
    {
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
        [MaxLength(100)]
        public string DevicesName { get; set; }

        [Required]
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
