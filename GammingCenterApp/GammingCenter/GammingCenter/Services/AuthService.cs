using GammingCenter.DTOs.Auth;
using GammingCenter.Models;
using GammingCenter.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GammingCenter.Services
{
    public class AuthService
    {
        private readonly VisitorRepository _repository;
        private readonly IConfiguration _configuration;

        // Constructor
        public AuthService(
            VisitorRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /////////////////////////////////////////////////////////
        // 1. Register Visitor
        /////////////////////////////////////////////////////////

        public bool Register(RegisterDto dto)
        {
            // Check if email already exists
            bool emailExists =
                _repository.EmailExists(dto.Email);

            if (emailExists)
            {
                return false;
            }

            // Hash password
            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    dto.Password);

            // Create Visitor
            Visitor visitor = new Visitor
            {
                VisitorName = dto.VisitorName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Age = dto.Age,
                Gender = dto.Gender,

                // Assign Visitor role by default
                Role = "Visitor"
            };

            // Save Visitor
            _repository.RegisterVisitor(visitor);

            return true;
        }

        /////////////////////////////////////////////////////////
        // 2. Login Visitor
        /////////////////////////////////////////////////////////

        public LoginResponseDto Login(LoginDto dto)
        {
            // Find Visitor by email
            Visitor visitor =
                _repository.Login(dto.Email);

            // Check if Visitor exists
            if (visitor == null)
            {
                return null;
            }

            // Verify password
            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    visitor.PasswordHash);

            // Check password
            if (!isPasswordValid)
            {
                return null;
            }

            // Generate JWT Token
            string token =
                GenerateJwtToken(visitor);

            // Return response
            return new LoginResponseDto
            {
                Token = token,
                Email = visitor.Email
            };
        }

        /////////////////////////////////////////////////////////
        // 3. Generate JWT Token
        /////////////////////////////////////////////////////////

        private string GenerateJwtToken(Visitor visitor)
        {
            var claims = new[]
            {
                // Visitor ID
                new Claim(
                    ClaimTypes.NameIdentifier,
                    visitor.VisitorId.ToString()),

                // Visitor Email
                new Claim(
                    ClaimTypes.Email,
                    visitor.Email),

                // Visitor Role
                new Claim(
                    ClaimTypes.Role,
                    visitor.Role)
            };

            // Get JWT Secret Key
            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]));

            // Create Signing Credentials
            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            // Create JWT Token
            var token =
     new JwtSecurityToken(
         issuer: _configuration["Jwt:Issuer"],
         audience: _configuration["Jwt:Audience"],
         claims: claims,
         expires: DateTime.UtcNow.AddHours(2),
         signingCredentials: credentials);

            // Return JWT Token
            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}