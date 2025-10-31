using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<List<RoomType>> GetAllRoomTypes();
        Task<RoomType> GetRoomTypeById(int roomTypeId);
        Task<RoomType> AddRoomType(RoomType roomType);
        Task<RoomType> UpdateRoomType(int roomTypeId, RoomType roomType);
        Task<RoomType> RemoveRoomType(int roomTypeId);
    }
}
