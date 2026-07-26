using GammingCenter.DTOs.CompetitionDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class CompetitionService
    {

        private CompetitionRepository repo;


        public CompetitionService(CompetitionRepository _repo)
        {
            repo = _repo;
        }

        // Create Competition
        public int CreateCompetition(CompetitionDTO dto)
        {

            Competition c = new Competition();


            c.CompetitionName = dto.CompetitionName;

            c.StartDate = dto.StartDate;

            c.EndDate = dto.EndDate;

            c.PlayersNo = dto.PlayersNo;

            c.DevicesName = dto.DevicesName;

            c.RoomId = dto.RoomId;


            // Default Status
            c.CompetitionStatus = "Upcoming";


            repo.CreateCompetition(c);


            return c.CompetitionId;
        }

    }  
}
