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
        public IActionResult AddDTOCompetition ([FromBody] CompetitionInputDTO competition)
        {
            int id = competitionService.CreateCompetition(competition);
            return Ok(new { CompetitionId = id });
        }

        // ==== Update Competition ====
       
        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]

        public IActionResult UpdateCompetition (int id, [FromBody] CompetitionInputDTO competition)
        {
            bool updated = competitionService.UpdateCompetition(id, competition);

            if (!updated)
                return NotFound();

            return Ok("Successfuly Updated");
        }

        // ==== Cancel Competition====
        public IActionResult CancelCompetition(int id)
        {
            bool cnacelled = competitionService.CancelCompetition(id);
            if (!cnacelled)
                return NotFound();

            return Ok("Successfuly Deleted");
        }


    }
}
