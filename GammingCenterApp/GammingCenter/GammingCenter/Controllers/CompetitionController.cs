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
        // ==== Get All Competition ====
        [AllowAnonymous]
        [HttpGet("GetAllCompetition")]
        public IActionResult GetAllProducts()
        {
            List<CompetitionOutputDTO> result = competitionService.GetAllCompetition();

            if (result.Count > 0)
            {
                return Ok(result);
            }

            return NoContent(); //204 no data
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

            return Ok("Successfuly Updated"); //return NoContent();
        }

        // ==== Cancel Competition====
        [Authorize(Roles = "Admin")]
        [HttpPut("CancelCompetition")]
        public IActionResult CancelCompetition(int id)
        {
            bool cnacelled = competitionService.CancelCompetition(id);
            if (!cnacelled)
                return NotFound();

            return Ok("Successfuly Deleted"); //return NoContent();
        }

        // === Update Competition Status ===
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateCompetitionStatus")]
        public IActionResult UpdateCompetitionStatus(int id, string status)
        {

            bool updated = competitionService.UpdateCompetitionStatus(id, status);

            if (!updated)
                return NotFound();
            return Ok("Successfuly Updated"); //return NoContent();

        }






    }
}
