using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO
{
    public class CustomerPostDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdProofNumber { get; set; }
    }
}
