using Hotel_Booking_System.DTO;
using Hotel_Booking_System.DTO.GetAllDtos;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomGetDto>> GetAllRooms();
        Task<RoomGetDto> GetById(int id);
        Task<Room> CreateRoom(Room room);
        Task<Room> UpdateRoom(int id, RoomPostDto roomPostDto);
        Task<Room> DeleteRoom(int id);
    }
}
