using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.DTO.GetAllDtos
{
    public class RoomTypeGetAllDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public List<RoomGetForRootypeGetDto> Rooms { get; set; }
    }
}
