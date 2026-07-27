using GammingCenter.DTOs.VisitorDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;
using Microsoft.Win32;

namespace GammingCenter.Services
{
    public class VisitorService
    {
        private VisitorRepository visitorRepository;

        public VisitorService(VisitorRepository _visitorRepository)
        {
            visitorRepository = _visitorRepository;
        }

        // 1. Register Visitor:
        public ResponseDto Register(ResponseDto dto)
        {
            
            if (visitorRepository.EmailExists(dto.Email))
                return null;

            Visitor visitor = new Visitor();
            visitor.VisitorName = dto.VisitorName;
            visitor.PhoneNumber = dto.PhoneNumber;
            visitor.Email = dto.Email;
            visitor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            visitor.Age = dto.Age;
            visitor.Gender = dto.Gender;

            visitorRepository.RegisterVisitor(visitor);

            ResponseDto response = new ResponseDto();
            response.VisitorId = visitor.VisitorId;
            response.VisitorName = visitor.VisitorName;
            response.Email = visitor.Email;
            response.PhoneNumber = visitor.PhoneNumber;
            response.Age = visitor.Age;
            response.Gender = visitor.Gender;
            response.Role = dto.Role;

            return response;
        }

        // 2. Login:
        public LoginResponseDto Login(LoginVisitorDto dto)
        {
            Visitor visitor = visitorRepository.Login(dto.Email);
            if (visitor == null)
                return null;

            bool validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, visitor.PasswordHash);
            if (!validPassword)
                return null;

            LoginResponseDto response = new LoginResponseDto();
            response.Token = "JWT_TOKEN_PLACEHOLDER";
            response.VisitorName = visitor.VisitorName;
            response.Role = "Visitor";

            return response;
        }

        // 3. Update Profile:
        public ResponseDto UpdateProfile(int visitorId, ResponseDto dto)
        {
            Visitor visitor = visitorRepository.GetById(visitorId);
            if (visitor == null)
            {
                return null;
            }

            visitor.VisitorName = dto.VisitorName;
            visitor.PhoneNumber = dto.PhoneNumber;
            visitor.Email = dto.Email;
            visitor.Age = dto.Age;
            visitor.Gender = dto.Gender;

            visitorRepository.Update();

            ResponseDto response = new ResponseDto();
            response.VisitorId = visitor.VisitorId;
            response.VisitorName = visitor.VisitorName;
            response.Email = visitor.Email;
            response.PhoneNumber = visitor.PhoneNumber;
            response.Age = visitor.Age;
            response.Gender = visitor.Gender;
            response.Role = "Visitor";

            return response;
        }

        // 4. View Booking History:
        public Visitor GetBookingHistory(int visitorId)
        {
            return visitorRepository.GetBookingHistory(visitorId);
        }

        // 5. View Competition History:
        public List<Competition> GetCompetitionHistory()
        {
            return visitorRepository.GetCompetitionHistory();
        }

        // Get Profile By ID:
        public ResponseDto GetById(int id)
        {
            Visitor visitor = visitorRepository.GetById(id);
            if (visitor == null)
                return null;

            ResponseDto response = new ResponseDto();
            response.VisitorId = visitor.VisitorId;
            response.VisitorName = visitor.VisitorName;
            response.Email = visitor.Email;
            response.PhoneNumber = visitor.PhoneNumber;
            response.Age = visitor.Age;
            response.Gender = visitor.Gender;
            response.Role = "Visitor";

            return response;
        }


    }
}
