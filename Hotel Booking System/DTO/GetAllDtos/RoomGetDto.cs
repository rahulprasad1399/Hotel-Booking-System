using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO.GetAllDtos
{
    public class RoomGetDto
    {

        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public decimal PricePerNight { get; set; }
        public int hotelId { get; set; }
        public string HotelName { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }

    }
}
