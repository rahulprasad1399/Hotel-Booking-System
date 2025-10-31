using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _bookingService.GetAllBooking());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var bookingFound = await _bookingService.GetBookingById(id);
            if(bookingFound == null)
            {
                return NotFound();
            } else
            {
                return Ok(bookingFound);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingPostDto bookingPostDto)
        {
            Booking booking = new Booking
            {
                CheckInDate = Convert.ToDateTime(bookingPostDto.CheckInDate),
                CheckOutDate = Convert.ToDateTime(bookingPostDto?.CheckOutDate),
                TotalAmount = bookingPostDto.TotalAmount,
                Status = bookingPostDto.Status,
                CustomerId = bookingPostDto.CustomerId,
                RoomId = bookingPostDto.RoomId,
            };

            Booking createdBooking = await _bookingService.CreateBookig(booking);
            return Ok(createdBooking);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateBooking(int id, BookingPostDto bookingPostDto)
        {
            Booking booking = new Booking
            {
                CheckInDate = Convert.ToDateTime(bookingPostDto.CheckInDate),
                CheckOutDate = Convert.ToDateTime(bookingPostDto?.CheckOutDate),
                TotalAmount = bookingPostDto.TotalAmount,
                Status = bookingPostDto.Status,
                CustomerId = bookingPostDto.CustomerId,
                RoomId = bookingPostDto.RoomId,
            };

            Booking updateBooking = await _bookingService.UpdateBooking(id, booking);
            if (updateBooking != null)
            {
                return Ok(updateBooking);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            Booking bookingDelete = await _bookingService.DeleteBooking(id);
            if(bookingDelete == null)
            {
                return NotFound();
            } else
            {
                return Ok(bookingDelete);
            }
        }
    }
}
