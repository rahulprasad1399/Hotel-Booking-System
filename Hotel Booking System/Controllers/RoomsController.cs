using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomservice;
        public RoomsController(IRoomService roomService) {
            _roomservice = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomPostDto roomPostDto)
        {

            Room room = new Room();
            room.RoomNumber = roomPostDto.RoomNumber;
            room.PricePerNight = roomPostDto.PricePerNight;
            room.Status = roomPostDto.Status;
            room.HotelId = roomPostDto.HotelId;
            room.RoomTypeId = roomPostDto.RoomTypeId;

            Room createdRoom = await _roomservice.CreateRoom(room);

            if (createdRoom != null)
            {
                return Ok(createdRoom);
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomservice.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roomFound = await _roomservice.GetById(id);
            if(roomFound != null)
            {
                return Ok(roomFound);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deletedRoom = await _roomservice.DeleteRoom(id);
            if(deletedRoom != null)
            {
                return Ok(deletedRoom);
            } else
            {
                return NotFound();
            }
            
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRoom(int id, RoomPostDto roomPostDto)
        {
            var updatedRoom = await _roomservice.UpdateRoom(id, roomPostDto);
            if(updatedRoom != null)
            {
                return Ok(roomPostDto);
            } else
            {
                return NotFound();
            }
        }
        
    }
}
;