using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hostelService) { 
            _hotelService = hostelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels() {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if(hotel == null)
            {
               return NotFound();
            }
            return Ok(hotel);   
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(HotelPostDto hotelPostDto)
        {
            var hotel = new Hotel
            {
                Name = hotelPostDto.Name,
                Address = hotelPostDto.Address,
                City = hotelPostDto.City,
                Country = hotelPostDto.Country,
                PhoneNumber = hotelPostDto.PhoneNumber,
            };

            await _hotelService.AddHotel(hotel);
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, HotelPostDto hotelPostDto)
        {

            var updatedHotel = await _hotelService.UpdateHotel(id, hotelPostDto);

            if(updatedHotel == null)
            {
                return NotFound();
            } else
            {
                return Ok(updatedHotel);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotelToDelete = await _hotelService.DeleteHotel(id);
            if(hotelToDelete == null)
            {
                return NotFound();
            } else
            {
                return Ok(hotelToDelete);
            }
        }

    }
}
