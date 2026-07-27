using GammingCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GammingCenter.Repositories
{
    public class ReviewRepository
    {
        private readonly GammingCenterContext Context;

        public ReviewRepository(GammingCenterContext _Context)
        {
            Context = _Context;
        }


        // Add Review:
        public void AddReview(Review review)
        {
            Context.Reviews.Add(review);
            Context.SaveChanges();
        }


        // Edit Review:
        public void EditReview(Review review)
        {
            Context.Reviews.Update(review);
            Context.SaveChanges();
        }


        // Delete Review:
        public void DeleteReview(Review review)
        {
            Context.Reviews.Remove(review);
            Context.SaveChanges();
        }


        // View Reviews:
        public List<Review> GetAllReviews()
        {
            return Context.Reviews
                .Include(r => r.Visitor)       
                .Include(r => r.GamingDevice)  
                .ToList();
        }

    }
}
