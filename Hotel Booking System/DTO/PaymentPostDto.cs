using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class PaymentPostDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public int BookingId { get; set; }
    }
}
