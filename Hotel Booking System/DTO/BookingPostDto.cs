using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class BookingPostDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
    }
}
