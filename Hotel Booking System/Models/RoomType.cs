using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Hotel_Booking_System.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
