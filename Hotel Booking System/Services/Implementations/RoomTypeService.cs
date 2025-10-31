using Hotel_Booking_System.Data;
using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelDbContext _context;
        public RoomTypeService(HotelDbContext hotelDbContext) { 
            _context = hotelDbContext;
        }

        public async Task<RoomType> AddRoomType(RoomType roomType)
        {
            await _context.roomTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
            return roomType;
        }

        public async Task<List<RoomType>> GetAllRoomTypes()
        {
            List<RoomType> roomTypes = await _context.roomTypes.ToListAsync();
            return roomTypes;
        }

        public async Task<RoomType> GetRoomTypeById(int roomTypeId)
        {
            var foundedRoomType = await _context.roomTypes.FirstOrDefaultAsync((roomtype)=>roomtype.Id == roomTypeId);    
            if(foundedRoomType == null) {
                return null;
            } else
            {
                return foundedRoomType; 
            }
        }

        public async Task<RoomType> RemoveRoomType(int roomTypeId)
        {
            var roomTypeToRemove = await _context.roomTypes.FirstOrDefaultAsync((roomType) => roomType.Id == roomTypeId);
            if(roomTypeToRemove == null)
            {
                return null;
            } else
            {
                 _context.roomTypes.Remove(roomTypeToRemove);
                 await _context.SaveChangesAsync();
                 return roomTypeToRemove; 
            }
        }

        public async Task<RoomType> UpdateRoomType(int roomTypeId, RoomType roomType)
        {
            var foundRoom = await _context.roomTypes.FirstOrDefaultAsync((roomType)=>roomType.Id == roomTypeId);    
            if(foundRoom == null)
            {
                return null;
            } else
            {
                foundRoom.Description = roomType.Description;
                foundRoom.TypeName = roomType.TypeName;
                foundRoom.Capacity = roomType.Capacity;
                await _context.SaveChangesAsync();
                return foundRoom;
            }
        }
    }
}
