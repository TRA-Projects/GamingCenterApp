using GammingCenter.DTOs.RoomDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService roomService;


    public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }


        //======================================================
        // Create Room

        [HttpPost]
        public IActionResult Create([FromBody] CreateRoomDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            roomService.CreateRoom(dto);

            return Ok("Room created successfully");
        }


        //======================================================
        // Update Room

        [HttpPut("{id}")]
        public IActionResult Edit(
            [FromRoute] int id,
            [FromBody] UpdateRoomDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            roomService.UpdateRoom(id, dto);

            return Ok("Room updated successfully");
        }


        //======================================================
        // View All Rooms

        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms =
                roomService.GetAllRooms();

            if (rooms == null || rooms.Count == 0)
            {
                return NoContent();
            }

            return Ok(rooms);
        }


        //======================================================
        // Check Room Availability

        [HttpGet("CheckAvailability/{id}")]
        public IActionResult CheckAvailability(
            [FromRoute] int id)
        {
            bool available =
                roomService.CheckRoomAvailability(id);

            return Ok(available);
        }


        //======================================================
        // View Devices In Room

        [HttpGet("{id}/Devices")]
        public IActionResult ViewDevices(
            [FromRoute] int id)
        {
            List<GamingDevice> devices =
                roomService.GetDevicesInRoom(id);

            if (devices == null || devices.Count == 0)
            {
                return NoContent();
            }

            return Ok(devices);
        }
    }


}
