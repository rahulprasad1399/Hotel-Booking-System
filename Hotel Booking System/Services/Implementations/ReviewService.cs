using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly HotelDbContext _context;
        public ReviewService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateReview(Review review)
        {
            await _context.reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteReview(int id)
        {
            Review reviewToBeDeleted = await _context.reviews.FirstOrDefaultAsync((review) => review.Id == id);
            if (reviewToBeDeleted != null)
            {
                _context.reviews.Remove(reviewToBeDeleted);
                await _context.SaveChangesAsync();
                return reviewToBeDeleted;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Review>> GetAllReviews()
        {
            List<Review> reviews = await _context.reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review> GetReviewById(int id)
        {
            Review review = await _context.reviews.FirstOrDefaultAsync((review) => review.Id == id);
            if (review != null)
            {
                return review;
            }
            else
            {
                return null;
            }
        }

        public async Task<Review> UpdateReview(int id, Review review)
        {


            Review updateReview = await _context.reviews.FirstOrDefaultAsync((review) => review.Id == id);

            if (updateReview == null)
            {
                return null;
            }

            review.Rating = review.Rating;
            review.Comment = review.Comment;
            review.ReviewDate = review.ReviewDate;
            review.HotelId = review.HotelId;
            review.CustomerId = review.CustomerId;

            return updateReview;
        }

    }
}
