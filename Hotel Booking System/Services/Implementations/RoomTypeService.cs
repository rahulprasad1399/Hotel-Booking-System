using Hotel_Booking_System.Data;
using Hotel_Booking_System.DTO;
using Hotel_Booking_System.DTO.GetAllDtos;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelDbContext _context;
        public RoomTypeService(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        public async Task<RoomType> AddRoomType(RoomType roomType)
        {
            await _context.roomTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
            return roomType;
        }

        public async Task<List<RoomTypeGetAllDto>> GetAllRoomTypes()
        {
            var roomTypes = await _context.roomTypes.Include(x => x.Rooms).Select(roomTypes => new RoomTypeGetAllDto
            {
                Id = roomTypes.Id,
                TypeName = roomTypes.TypeName,
                Description = roomTypes.Description,
                Capacity = roomTypes.Capacity,
                Rooms = roomTypes.Rooms.Select(room => new RoomGetForRootypeGetDto
                {
                    Id = room.Id,
                    RoomNumber = room.RoomNumber,
                    RoomStatus = room.Status,
                    PricePerNight = room.PricePerNight,
                    hotelId = room.HotelId,
                    HotelName = room.Hotel.Name
                }).ToList()
            }).ToListAsync();

            return roomTypes;
        }

        public async Task<RoomTypeGetAllDto> GetRoomTypeById(int roomTypeId)
        {
            var foundedRoomType = await _context.roomTypes.Where((roomType) => roomType.Id == roomTypeId).Select((roomType) => new RoomTypeGetAllDto
            {
                Id = roomType.Id,
                TypeName = roomType.TypeName,
                Description = roomType.Description,
                Capacity = roomType.Capacity,
                Rooms = roomType.Rooms.Select((room) => new RoomGetForRootypeGetDto
                {
                    Id = room.Id,
                    RoomNumber = room.RoomNumber,
                    RoomStatus = room.Status,
                    PricePerNight = room.PricePerNight,
                    hotelId = room.HotelId,
                    HotelName = room.Hotel.Name
                }).ToList()
            }).FirstOrDefaultAsync();

            //var roomFound = await _context.roomTypes.Where((id)=>id.Id == roomTypeId).Include((x)=>x.Rooms).ThenInclude(x=>x.Hotel).FirstOrDefaultAsync(x=>x.Id == roomTypeId);

            //var roomTypeForGetById = new RoomTypeGetAllDto();
            //roomTypeForGetById.Id = roomFound.Id;
            //roomTypeForGetById.TypeName = roomFound.TypeName;
            //roomTypeForGetById.Description = roomFound.Description;
            //roomTypeForGetById.Capacity = roomFound.Capacity;
            //roomTypeForGetById.Rooms = roomFound.Rooms.Select((room)=>new RoomGetForRootypeGetDto
            //{
            //    Id=room.Id,
            //    RoomNumber=room.RoomNumber,
            //    RoomStatus=room.Status,
            //    PricePerNight=room.PricePerNight,
            //    hotelId=room.HotelId,
            //    HotelName = room.Hotel.Name
            //}).ToList();

            if (foundedRoomType == null)
            {
                return null;
            }
            else
            {
                return foundedRoomType;
            }
        }

        public async Task<RoomType> RemoveRoomType(int roomTypeId)
        {
            var roomTypeToRemove = await _context.roomTypes.FirstOrDefaultAsync((roomType) => roomType.Id == roomTypeId);
            if (roomTypeToRemove == null)
            {
                return null;
            }
            else
            {
                _context.roomTypes.Remove(roomTypeToRemove);
                await _context.SaveChangesAsync();
                return roomTypeToRemove;
            }
        }

        public async Task<RoomType> UpdateRoomType(int roomTypeId, RoomType roomType)
        {
            var foundRoom = await _context.roomTypes.FirstOrDefaultAsync((roomType) => roomType.Id == roomTypeId);
            if (foundRoom == null)
            {
                return null;
            }
            else
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
