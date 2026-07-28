using GammingCenter.DTOs.VisitorDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _service;


    // Constructor
    public VisitorController(VisitorService service)
        {
            _service = service;
        }

        // 1 - Update Visitor Profile
        [HttpPut("{visitorId}")]
        public IActionResult UpdateProfile(
            [FromRoute] int visitorId,
            [FromBody] UpdateVisitorDto dto)
        {
            ResponseDto result =
                _service.UpdateProfile(visitorId, dto);

            // Check if visitor exists
            if (result == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(result);
        }

        // 2 - View Visitor By ID
        [HttpGet("{visitorId}")]
        public IActionResult GetById(
            [FromRoute] int visitorId)
        {
            ResponseDto visitor = _service.GetById(visitorId);

            // Check if visitor exists
            if (visitor == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(visitor);
        }

        // 3 - View Booking History
        [HttpGet("{visitorId}/booking-history")]
        public IActionResult GetBookingHistory(
            [FromRoute] int visitorId)
        {
            Visitor history =
                _service.GetBookingHistory(visitorId);

            // Check if visitor exists
            if (history == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(history);
        }

        // 4 - View Competition History
        [HttpGet("competition-history")]
        public IActionResult GetCompetitionHistory(
            [FromQuery] string status)
        {
            List<Competition> competitions =
                _service.GetCompetitionHistory();

            return Ok(competitions);
        }
    }


}
