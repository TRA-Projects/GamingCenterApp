using GammingCenter.DTOs.CompetitionDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Services
{
    public class CompetitionService
    {

        private CompetitionRepository repo;


        public CompetitionService(CompetitionRepository _repo)
        {
            repo = _repo;
        }

        // ==== Create Competition =====
        public int CreateCompetition(CompetitionInputDTO dto)
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
        // ==== Update Competition ====
        public bool UpdateCompetition(int id, CompetitionInputDTO dto)
        {
            Competition competition = repo.GetCompetitionById(id);


            if (competition == null)
                return false;

            competition.CompetitionName = dto.CompetitionName;
            competition.StartDate = dto.StartDate;
            competition.EndDate = dto.EndDate;
            competition.PlayersNo = dto.PlayersNo;
            competition.DevicesName = dto.DevicesName;
            competition.RoomId = dto.RoomId;

            repo.UpdateCompetition();

            return true;
        }
        // ==== Cancel Competition====
        public bool CancelCompetition(int id)
        {
            Competition competition = repo.GetCompetitionById(id);

            if (competition == null)
                return false;

            competition.CompetitionStatus = "Cancelled";

            repo.CancelCompetition();

            return true;
        }


    }
}
