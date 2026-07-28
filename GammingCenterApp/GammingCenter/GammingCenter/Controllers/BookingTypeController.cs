using GammingCenter.DTOs.BookingType;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingTypeController : ControllerBase
    {
        // Allow Controller to Access Service
        private readonly BookingTypeService _service;


    // Constructor
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
        [HttpPut("{BookingTypeId}")]
        public IActionResult UpdateBookingType(
            int BookingTypeId,
            BookingTypeUpdateDto dto)
        {
            bool result = _service.UpdateBookingType(BookingTypeId, dto);

            // Check if ID exists
            if (!result)
            {
                return NotFound("Booking type not found");
            }

            return Ok("Booking type updated successfully");
        }

        ////////////////////////////////////////////////////////

        // 3- Delete Booking Type
        [HttpDelete("{BookingTypeId}")]
        public IActionResult DeleteBookingType(int BookingTypeId)
        {
            bool result = _service.DeleteBookingType(BookingTypeId);

            // Check if ID exists
            if (!result)
            {
                return NotFound("Booking type not found");
            }

            return Ok("Booking type deleted successfully");
        }

        ////////////////////////////////////////////////////////

        // 4- View Booking Types
        [HttpGet]
        public IActionResult GetBookingTypes()
        {
            List<BookingTypeResponseDto> bookingTypeResponse =
                _service.GetBookingTypes();

            return Ok(bookingTypeResponse);
        }
    }


}
