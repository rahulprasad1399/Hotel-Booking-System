using Hotel_Booking_System.Data;
using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _context;
        public HotelService(HotelDbContext context) { 
            _context = context;
        }
        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            _context.hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            Hotel hotelToDelete = await _context.hotels.FirstOrDefaultAsync((hotel)=>hotel.Id == id);
            if(hotelToDelete != null)
            {
                _context.hotels.Remove(hotelToDelete);
                await _context.SaveChangesAsync();
                return hotelToDelete;
            } else
            {
                return null;
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            List<Hotel> hotels = await _context.hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            Hotel hotelFound = await _context.hotels.FirstOrDefaultAsync((h) => h.Id == id);
            return hotelFound;
        }

        public async Task<Hotel> UpdateHotel(int id, HotelPostDto hotelPostDto)
        {

            Hotel existingHotel = await _context.hotels.FirstOrDefaultAsync((hotel) => hotel.Id == id); 

            if(existingHotel != null)
            {
                existingHotel.Address = hotelPostDto.Address;
                existingHotel.PhoneNumber = hotelPostDto.PhoneNumber;
                existingHotel.Name = hotelPostDto.Name;
                existingHotel.City  = hotelPostDto.City;
                existingHotel.Country = hotelPostDto.Country;
                
                await _context.SaveChangesAsync();
                return existingHotel;
            } else
            {
                return null;
            }
        }
    }
}
