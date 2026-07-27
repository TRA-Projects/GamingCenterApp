using GammingCenter.DTOs.BookingType;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingTypeController:ControllerBase
    {
        //Allow Controller to Access Service
        private readonly BookingTypeService _service;

        //constrator
        public BookingTypeController(BookingTypeService service)
        {
            _service = service;
        }

        /////////////////////////////////////////////////////////


        // 1- Add Booking Type

        [HttpPost]
        public IActionResult AddGamingDevice(BookingTypeCreateDto dto)
        {
            _service.AddBookingType(dto);

            return Ok("Booking type added successfully");
        }

        ////////////////////////////////////////////////////////


        // 2- Update Booking Type
        public IActionResult 

    }
}
