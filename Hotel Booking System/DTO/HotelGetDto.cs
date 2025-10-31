using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class HotelGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
