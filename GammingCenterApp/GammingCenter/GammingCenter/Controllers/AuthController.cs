using GammingCenter.DTOs.Auth;
using GammingCenter.DTOs.VisitorDTO;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        // Constructor
        public AuthController(AuthService service)
        {
            _service = service;
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