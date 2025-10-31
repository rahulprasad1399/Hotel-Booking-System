using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService) {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomType(RoomTypePostDto roomTypePostDto)
        {
            RoomType roomType = new RoomType();
            roomType.Description = roomTypePostDto.Description;
            roomType.TypeName = roomTypePostDto.TypeName;
            roomType.Capacity = roomTypePostDto.Capacity;

            RoomType newRoomType = await _roomTypeService.AddRoomType(roomType);

            if(newRoomType != null)
            {
                return Ok(newRoomType);
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypes();
            return Ok(roomTypes);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomTypeFound = await _roomTypeService.GetRoomTypeById(id);
            if(roomTypeFound != null)
            {
                return Ok(roomTypeFound);
            } else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, RoomTypePostDto roomTypePostDto)
        {
            RoomType roomType = new RoomType();
            roomType.TypeName = roomTypePostDto.TypeName;
            roomType.Description = roomTypePostDto.Description;
            roomType.Capacity = roomTypePostDto.Capacity;

            var updatedRoomType =  await _roomTypeService.UpdateRoomType(id, roomType);
            if(updatedRoomType != null)
            {
                return Ok(updatedRoomType);
            } else { 
                return NotFound(); 
            }   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var deleteRoomType = await _roomTypeService.RemoveRoomType(id);
            if(deleteRoomType != null)
            {
                return Ok(deleteRoomType);
            } else
            {
                return NotFound();
            }
        }
        
    }
}
