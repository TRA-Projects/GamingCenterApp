using GammingCenter.DTOs.ReviewDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository reviewRepository;

        public ReviewService(ReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        //1. Add Review:

        public ReviewResponseDto AddReview(CreateReviewDto dto)
        {
            Review review = new Review();
            review.rating = dto.Rating;
            review.comment = dto.Comment;
            review.visitorId = dto.VisitorId;
            review.deviceId = dto.deviceId;
            review.reviewDate = DateTime.Now;

            reviewRepository.AddReview(review);

            ReviewResponseDto response = new ReviewResponseDto();
            response.reviewId = review.reviewId;
            response.rating = review.rating;
            response.comment = review.comment;
            response.reviewDate = review.reviewDate;
            response.visitorId = review.visitorId;
            response.deviceId = review.deviceId;

            return response;
        }

        //  2. Edit Review:
        public ReviewResponseDto EditReview(int reviewId, UpdateReviewDto dto)
        {
            Review review = reviewRepository.GetAllReviews()
                .FirstOrDefault(r => r.reviewId == reviewId);

            if (review == null)
                return null;

            review.rating = dto.Rating;
            review.comment = dto.Comment;

            reviewRepository.EditReview(review);

            ReviewResponseDto response = new ReviewResponseDto();
            response.reviewId = review.reviewId;
            response.rating = review.rating;
            response.comment = review.comment;
            response.reviewDate = review.reviewDate;
            response.visitorId = review.visitorId;
            response.visitorName = review.Visitor != null ? review.GamingDevice.DeviceName : "";
            response.deviceId = review.deviceId;
            response.deviceName = review.GamingDevice != null ? review.GamingDevice.DeviceName : "";

            return response;
        }

        // 3. Delete Review:
        public bool DeleteReview(int reviewId)
        {
            Review review = reviewRepository.GetAllReviews()
                .FirstOrDefault(r => r.reviewId == reviewId);

            if (review == null)
                return false;

            reviewRepository.DeleteReview(review);
            return true;
        }

        // 4. View Reviews:
        public List<ReviewResponseDto> GetAllReviews()
        {
            List<Review> reviews = reviewRepository.GetAllReviews();
            List<ReviewResponseDto> responseList = new List<ReviewResponseDto>();

            foreach (var r in reviews)
            {
                ReviewResponseDto dto = new ReviewResponseDto();
                dto.reviewId = r.reviewId;
                dto.rating = r.rating;
                dto.comment = r.comment;
                dto.reviewDate = r.reviewDate;
                dto.visitorId = r.visitorId;
                dto.visitorName = r.Visitor != null ? r.Visitor.VisitorName : "";
                dto.deviceId = r.deviceId;
                dto.deviceName = r.GamingDevice != null ? r.GamingDevice.DeviceName : "";

                responseList.Add(dto);
            }

            return responseList;
        }



    }
}
