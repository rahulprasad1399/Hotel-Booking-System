using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class ReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int HotelId { get; set; }
        public int CustomerId { get; set; }
    }
}
