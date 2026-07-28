using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;


    public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        //======================================================
        // Create Booking
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] CreateBookingDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return Unauthorized("Visitor ID not found in token.");
            }

            int visitorId = int.Parse(claim.Value);

            bookingService.CreateBooking(dto, visitorId);

            return Ok("Booking created successfully");
        }


        //======================================================
        // Update Booking

        [HttpPut("{id}")]
        public IActionResult Edit(
            [FromRoute] int id,
            [FromBody] UpdateBookingDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bookingService.UpdateBooking(id, dto);

            return Ok("Booking updated successfully");
        }


        //======================================================
        // Cancel Booking

        [HttpPut("Cancel/{id}")]
        public IActionResult Cancel([FromRoute] int id)
        {
            bookingService.CancelBooking(id);

            return Ok("Booking cancelled successfully");
        }


        //======================================================
        // View Booking Details

        [HttpGet("{id}")]
        public IActionResult Details([FromRoute] int id)
        {
            BookingDetailsDTO booking =
                bookingService.GetBookingDetails(id);

            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            return Ok(booking);
        }


        //======================================================
        // View Visitor Bookings

        [HttpGet("Visitor/{id}")]
        public IActionResult VisitorBookings([FromRoute] int id)
        {
            List<BookingListDTO> bookings =
                bookingService.GetVisitorBookings(id);

            return Ok(bookings);
        }


        //======================================================
        // Calculate Total Price

        [HttpGet("CalculatePrice/{deviceId}/{hours}")]
        public IActionResult CalculatePrice(
            [FromRoute] int deviceId,
            [FromRoute] int hours)
        {
            decimal totalPrice =
                bookingService.CalculateTotalPrice(deviceId, hours);

            return Ok(totalPrice);
        }


        //======================================================
        // Check Device Availability

        [HttpGet("CheckAvailability/{deviceId}/{slotId}")]
        public IActionResult CheckAvailability(
            [FromRoute] int deviceId,
            [FromRoute] int slotId)
        {
            bool available =
                bookingService.CheckDeviceAvailability(deviceId, slotId);

            return Ok(available);
        }
    }


}
