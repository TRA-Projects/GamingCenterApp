using GammingCenter.DTOs.VisitorDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        // Allow Controller to Access Service
        private readonly VisitorService _service;

        // Constructor
        public VisitorController(VisitorService service)
        {
            _service = service;
        }

        

        // 1-Register Visitor

        [HttpPost("register")]
        public IActionResult Register(RegisterVisitorDto dto)
        {
            ResponseDto result = _service.Register(dto);

            // Check if email already exists
            if (result == null)
            {
                return BadRequest("Email is already registered");
            }

            return Ok(result);
        }

        

        // 2-Login Visitor

        [HttpPost("login")]
        public IActionResult Login(LoginVisitorDto dto)
        {
            LoginResponseDto result = _service.Login(dto);

            // Validate credentials
            if (result == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(result);
        }

       

        // 3-Update Visitor Profile

        [HttpPut("{visitorId}")]
        public IActionResult UpdateProfile(int visitorId, ResponseDto dto)
        {
            ResponseDto result = _service.UpdateProfile(visitorId, dto);

            // Check if the visitor exists
            if (result == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(result);
        }

        

        // 4-View Visitor By ID

        [HttpGet("{visitorId}")]
        public IActionResult GetById(int visitorId)
        {
            ResponseDto visitor = _service.GetById(visitorId);

            // Validate input
            if (visitor == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(visitor);
        }

        

        // 5-View Booking History

        [HttpGet("{visitorId}/booking-history")]
        public IActionResult GetBookingHistory(int visitorId)
        {
            Visitor history = _service.GetBookingHistory(visitorId);

            // Validate input
            if (history == null)
            {
                return NotFound("Visitor not found");
            }

            return Ok(history);
        }

        
        // 6-View Competition History

        [HttpGet("competition-history")]
        public IActionResult GetCompetitionHistory()
        {
            List<Competition> competitions = _service.GetCompetitionHistory();

            return Ok(competitions);
        }
    }
}
