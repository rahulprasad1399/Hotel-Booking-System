using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class RoomPostDto
    {
        public string RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public RoomStatus Status { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
    }
}
