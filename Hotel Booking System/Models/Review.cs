namespace Hotel_Booking_System.Models
{
    public class Review
    { 
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer {  get; set; }
    }
}
