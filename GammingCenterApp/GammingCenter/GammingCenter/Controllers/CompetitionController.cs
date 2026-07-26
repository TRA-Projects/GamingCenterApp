using GammingCenter.DTOs.CompetitionDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GammingCenter.Controllers
    
{
    [ApiController]
    [Route("competition")]
    public class CompetitionController : ControllerBase
    {
        //constructor
        private CompetitionService competitionService;



        public CompetitionController(CompetitionService _competitionService)
        {
            competitionService = _competitionService;
        }

        // ==== Create Competition ====
        [Authorize(Roles = "Admin")]
        [HttpPost("AddDTO")]
        public IActionResult AddDTOCompetition ([FromBody] CompetitionDTO competition)
        {
            int id = competitionService.CreateCompetition(competition);
            return Ok(new { CompetitionId = id });
        }








    }
}
