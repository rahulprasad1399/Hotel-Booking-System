namespace Hotel_Booking_System.Models
{
    public class Room
    { 
        public int Id { get; set; }
        public string RoomNumber {  get; set; }
        public decimal PricePerNight { get; set; }
        public RoomStatus Status { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public List<Booking> Bookings { get; set; }
    }

    public enum RoomStatus
    {
        Available,
        Booked,
        UnderMaintenance
    }
}
