using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(int id);
        Task<Booking> CreateBookig(Booking booking);
        Task<Booking> UpdateBooking(int id, Booking booking);
        Task<Booking> DeleteBooking(int id);
    }
}
