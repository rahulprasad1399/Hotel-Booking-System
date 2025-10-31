using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task<Review> CreateReview(Review review);
        Task<Review> UpdateReview(int id, Review review);
        Task<Review> DeleteReview(int id);
    }
}
