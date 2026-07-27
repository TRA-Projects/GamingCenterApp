using GammingCenter.DTOs.RoomDTO;
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
        }
}
