using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.ReviewDTO
{
    public class CreateReviewDto
    {
        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }


        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string Comment { get; set; } 


        [Required(ErrorMessage = "VisitorId is required.")]
        public int VisitorId { get; set; }

        [Required(ErrorMessage = "Gaming Device is required.")]
        public int deviceId { get; set; }
    }
}
