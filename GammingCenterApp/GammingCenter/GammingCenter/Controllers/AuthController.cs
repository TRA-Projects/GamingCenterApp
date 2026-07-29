using GammingCenter.DTOs.Auth;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;
        private readonly EmailService emailService;

        // Constructor
        public AuthController(AuthService service,EmailService _emailService)
        {
            _service = service;
            emailService = _emailService;
        }

        /////////////////////////////////////////////////////////
        // 1. Register Visitor
        /////////////////////////////////////////////////////////

        [HttpPost("register")]
        public IActionResult Register(
            [FromBody] RegisterDto dto)
        {
            bool result =
                _service.Register(dto);

            // Check if email already exists
            if (!result)
            {
                return BadRequest(
                    "Email already exists");
            }

            emailService.SendEmailAsync("test@gmail.com", "Welcome to Gaming Center!", "$\"<h1>Hello {dto.VisitorName}!</h1><p>Welcome to Gaming Center. Your account has been created successfully!</p>\";"); 

            return Ok(
                "Visitor registered successfully");
        }

        /////////////////////////////////////////////////////////
        // 2. Login Visitor
        /////////////////////////////////////////////////////////

        [HttpPost("login")]
        public IActionResult Login(
            [FromBody] LoginDto dto)
        {
            LoginResponseDto response =
                _service.Login(dto);

            // Check if email or password is incorrect
            if (response == null)
            {
                return Unauthorized(
                    "Invalid email or password");
            }

            // Return JWT Token
            return Ok(response);
        }
    }
}