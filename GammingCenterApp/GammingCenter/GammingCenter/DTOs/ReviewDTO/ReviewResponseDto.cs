namespace GammingCenter.DTOs.ReviewDTO
{
    public class ReviewResponseDto
    {
        public int reviewId { get; set; }
        public int rating { get; set; }
        public string? comment { get; set; }
        public DateTime reviewDate { get; set; }

        
        public int visitorId { get; set; }
        public int deviceId { get; set; }
         
    }
}
