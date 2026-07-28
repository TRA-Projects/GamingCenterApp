using GammingCenter.DTOs.VisitorDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;
using Org.BouncyCastle.Asn1.Ocsp;

namespace GammingCenter.Services
{
    public class VisitorService
    {
        private readonly VisitorRepository visitorRepository;

    // Constructor
    public VisitorService(VisitorRepository _visitorRepository)
        {
            visitorRepository = _visitorRepository;
        }

        // 1. Update Visitor Profile
        public ResponseDto UpdateProfile(
            int visitorId,
            UpdateVisitorDto dto)
        {
            Visitor visitor =
                visitorRepository.GetById(visitorId);

            // Check if visitor exists
            if (visitor == null)
            {
                return null;
            }

            // Update Visitor Information
            visitor.VisitorName = dto.VisitorName;
            visitor.PhoneNumber = dto.PhoneNumber;
            visitor.Age = dto.Age;
            visitor.Gender = dto.Gender;

            // Save changes
            visitorRepository.Update();

            // Create response
            ResponseDto response = new ResponseDto
            {
                VisitorId = visitor.VisitorId,
                VisitorName = visitor.VisitorName,
                Email = visitor.Email,
                PhoneNumber = visitor.PhoneNumber,
                Age = visitor.Age,
                Gender = visitor.Gender,
                Role = visitor.Role
            };

            return response;
        }

        // 2. View Visitor Profile By ID
        public ResponseDto GetById(int id)
        {
            Visitor visitor =
                visitorRepository.GetById(id);

            // Check if visitor exists
            if (visitor == null)
            {
                return null;
            }

            // Create response
            ResponseDto response = new ResponseDto
            {
                VisitorId = visitor.VisitorId,
                VisitorName = visitor.VisitorName,
                Email = visitor.Email,
                PhoneNumber = visitor.PhoneNumber,
                Age = visitor.Age,
                Gender = visitor.Gender,
                Role = visitor.Role
            };

            return response;
        }

        // 3. View Booking History
        public Visitor GetBookingHistory(int visitorId)
        {
            return visitorRepository.GetBookingHistory(visitorId);
        }

        // 4. View Competition History
        public List<Competition> GetCompetitionHistory()
        {
            return visitorRepository.GetCompetitionHistory();
        }
    }


}
