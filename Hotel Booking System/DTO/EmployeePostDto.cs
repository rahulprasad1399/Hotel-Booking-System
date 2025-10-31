using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class EmployeePostDto
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int HotelId { get; set; }
    }
}
