using GammingCenter.DTOs.RoomDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    public class RoomController : Controller
    {

        private RoomService roomService;


        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }



        //======================================================
        // Create Room


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateRoomDTO dto)
        {
            if (ModelState.IsValid)
            {
                roomService.CreateRoom(dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }



        //======================================================
        // Update Room


        [HttpGet]
        public IActionResult Edit(
            [FromRoute] int id)
        {
            return View();
        }



        [HttpPost]
        public IActionResult Edit(
            [FromRoute] int id,
            [FromBody] UpdateRoomDTO dto)
        {
            if (ModelState.IsValid)
            {
                roomService.UpdateRoom(id, dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }



        //======================================================
        // View All Rooms


        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms =
                roomService.GetAllRooms();

            return View(rooms);
        }



        //======================================================
        // Check Room Availability


        [HttpGet]
        public IActionResult CheckAvailability(
            [FromRoute] int id)
        {
            bool available =
                roomService.CheckRoomAvailability(id);

            return Json(available);
        }



        //======================================================
        // View Devices In Room


        [HttpGet]
        public IActionResult ViewDevices(
            [FromRoute] int id)
        {
            List<GamingDevice> devices =
                roomService.GetDevicesInRoom(id);

            return View(devices);
        }
    }
}