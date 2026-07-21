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
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(2, 100, ErrorMessage = "Players number must be between 2 and 100")]
        public int PlayersNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompetitionStatus { get; set; }

        [Required]
        [MaxLength(100)]
        public string DevicesName { get; set; }

    }
}
