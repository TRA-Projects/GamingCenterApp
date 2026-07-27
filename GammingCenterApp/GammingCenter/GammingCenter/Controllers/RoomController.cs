using GammingCenter.DTOs.RoomDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    public class RoomController: Controller
    {
        // Service object used to perform room operations
        private RoomService roomService;

        public RoomController(RoomService roomService)
        {
            // Dependency Injection
            this.roomService = roomService;
        }

        // Display Create Room page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save a new room
        [HttpPost]
        public IActionResult Create(RoomDTO dto)
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

        // Display Update Room page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // Update room information
        [HttpPost]
        public IActionResult Edit(int id, RoomDTO dto)
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

        // Display all rooms
        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms = roomService.GetAllRooms();

            return View(rooms);
        }

        //======================================================
        // Check Room Availability

        // Check if a room is available
        [HttpGet]
        public IActionResult CheckAvailability(int id)
        {
            bool available = roomService.CheckRoomAvailability(id);

            return Json(available);
        }

        //======================================================
        // View Devices in Room

        // Display all gaming devices in a room
        [HttpGet]
        public IActionResult ViewDevices(int id)
        {
            List<GamingDevice> devices = roomService.GetDevicesInRoom(id);

            return View(devices);
        }
    }
}
