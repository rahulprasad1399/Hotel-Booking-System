using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> AddHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(int id, HotelPostDto hotel);
        Task<Hotel> DeleteHotel(int id);
       
    }
}
