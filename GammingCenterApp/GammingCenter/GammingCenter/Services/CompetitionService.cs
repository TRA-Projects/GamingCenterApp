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
        // ==== view All Competition ====
        public List<CompetitionOutputDTO> GetAllCompetition()
        {
            return repo.GetAllCompetition()
                       .Select(c => new CompetitionOutputDTO
                       {
                           CompetitionId=c.CompetitionId,
                           CompetitionName =c.CompetitionName,
                           StartDate = c.StartDate,
                           EndDate = c.EndDate,
                           PlayersNo = c.PlayersNo,
                           CompetitionStatus = c.CompetitionStatus,
                           DevicesName = c.DevicesName,
                           RoomId = c.RoomId,
                       })
                       .ToList();
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
        // === Update Competition Status ===
        public bool UpdateCompetitionStatus(int id,string status)
        {
            Competition competition = repo.GetCompetitionById(id);

            if (competition == null)
                return false;

            competition.CompetitionStatus = status;

            repo.UpdateCompetitionStatus();

            return true;
        }
        // === Search Competition by Name ===

        public List<CompetitionOutputDTO> SearchCompetitionByName(string name)
        {
            return repo.SearchCompetitionByName(name)
               .Select(c => new CompetitionOutputDTO
               {
                   CompetitionId = c.CompetitionId,
                   CompetitionName = c.CompetitionName,
                   StartDate = c.StartDate,
                   EndDate = c.EndDate,
                   PlayersNo = c.PlayersNo,
                   CompetitionStatus = c.CompetitionStatus,
                   DevicesName = c.DevicesName,
                   RoomId = c.RoomId
               })
               .ToList();
        }

        // === Search Competition by Status ===
        public List<CompetitionOutputDTO> SearchCompetitionByStatus(string status)
        {
            return repo.SearchCompetitionByStatus(status).Select(c => new CompetitionOutputDTO
            {
                CompetitionId = c.CompetitionId,
                CompetitionName = c.CompetitionName,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                PlayersNo = c.PlayersNo,
                CompetitionStatus = c.CompetitionStatus,
                DevicesName = c.DevicesName,
                RoomId = c.RoomId
            }).ToList();
        }







    }
}
