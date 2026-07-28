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
        
        private readonly VisitorService _service;
        private readonly EmailService _emailservice;

        // Constructor
        public VisitorController(VisitorService service, EmailService emailservice)
        {
            _service = service;
            _emailservice = emailservice;
        }

  

        // 1-Register Visitor

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterVisitorDto dto)
        {
            ResponseDto result = _service.Register(dto);

            // Check if email already exists
            if (result == null)
            {
                return BadRequest("Email is already registered");
            }
            _emailservice.SendEmailAsync("Gamining@gmail.com", "Welcome to Gaming Center!", "Hello, thank you for registering with us! Your account has been successfully created.");

            return Ok(result);
        }

        

        // 2-Login Visitor

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginVisitorDto dto)
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
        public IActionResult UpdateProfile([FromRoute] int visitorId, [FromBody] ResponseDto dto)
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
        public IActionResult GetById([FromRoute]int visitorId)
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
        public IActionResult GetBookingHistory([FromRoute] int visitorId)
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
        public IActionResult GetCompetitionHistory([FromQuery] string status)
        {
            List<Competition> competitions = _service.GetCompetitionHistory();

            return Ok(competitions);
        }
    }
}
