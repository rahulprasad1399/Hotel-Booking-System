using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly HotelDbContext _context;
        public BookingService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Booking> CreateBookig(Booking booking)
        {
            await _context.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> DeleteBooking(int id)
        {
            Booking bookingToDelete = await _context.bookings.FirstOrDefaultAsync((booking) => booking.Id == id);
            if (bookingToDelete != null)
            {
                _context.bookings.Remove(bookingToDelete);
                await _context.SaveChangesAsync();
                return bookingToDelete;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Booking>> GetAllBooking()
        {
            List<Booking> bookings = await _context.bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking> GetBookingById(int id)
        {
            Booking existingBooking = await _context.bookings.FirstOrDefaultAsync((booking)=>booking.Id == id);
            if (existingBooking != null)
            {
                return existingBooking;
            } else
            {
                return null; 
            }
        }

        public async Task<Booking> UpdateBooking(int id, Booking booking)
        {

        Booking bookingToUpdate = await _context.bookings.FirstOrDefaultAsync((booking) => booking.Id == id);
            if (bookingToUpdate != null)
            {
                bookingToUpdate.CheckInDate = Convert.ToDateTime(booking.CheckInDate);
                bookingToUpdate.CheckOutDate = Convert.ToDateTime(booking.CheckOutDate);
                bookingToUpdate.TotalAmount = Convert.ToDecimal(booking.TotalAmount);
                bookingToUpdate.Status = booking.Status;
                bookingToUpdate.CustomerId = booking.CustomerId;
                bookingToUpdate.RoomId = booking.RoomId;

                await _context.SaveChangesAsync();
                return bookingToUpdate;
            }
            else
            {
                return null;
            }
        }
    }
}
