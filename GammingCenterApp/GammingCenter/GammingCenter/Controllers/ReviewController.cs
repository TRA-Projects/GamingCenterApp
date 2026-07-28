using GammingCenter.DTOs.ReviewDTO;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class ReviewController : ControllerBase
        {
            // Allow Controller to Access Service
            private readonly ReviewService _service;

            // Constructor
            public ReviewController(ReviewService service)
            {
                _service = service;
            }


            // 1-Add Review

            [HttpPost]
            public IActionResult AddReview(CreateReviewDto dto)
            {
                ReviewResponseDto review = _service.AddReview(dto);

                return Ok(review);
            }


            // 2-Edit Review

            [HttpPut("{reviewId}")]
            public IActionResult EditReview(int reviewId, UpdateReviewDto dto)
            {
                ReviewResponseDto result = _service.EditReview(reviewId, dto);

                // Check if the review exists
                if (result == null)
                {
                    return NotFound("Review not found");
                }

                return Ok(result);
            }


            // 3-Delete Review Method

            [HttpDelete("{reviewId}")]
            public IActionResult DeleteReview(int reviewId)
            {
                bool result = _service.DeleteReview(reviewId);

                // Validate input
                if (!result)
                {
                    return NotFound("Review not found");
                }

                return Ok("Review deleted successfully");
            }


            // 4-View All Reviews Method

            [HttpGet]
            public IActionResult GetAllReviews()
            {
                List<ReviewResponseDto> reviews = _service.GetAllReviews();

                return Ok(reviews);
            }
        }
}
