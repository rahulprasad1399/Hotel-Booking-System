using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            List<Review> reviews = await _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            Review review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(review);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewDto reviewDto)
        {

            Review newReview = new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = reviewDto.ReviewDate,
                HotelId = reviewDto.HotelId,
                CustomerId = reviewDto.CustomerId,
            };

            var createdReview = await _reviewService.CreateReview(newReview);
            if (createdReview == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(createdReview);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(int id)
        {
            Review review = await _reviewService.DeleteReview(id);
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(review);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateReview(int id, ReviewDto reviewDto)
        {

            Review review = new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = Convert.ToDateTime(reviewDto.ReviewDate) ,
                HotelId = reviewDto.HotelId,
                CustomerId = reviewDto.CustomerId,
            };

            var updatedReview = await _reviewService.UpdateReview(id, review);
            if (updatedReview == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(review);
            }
        }
    }
}
