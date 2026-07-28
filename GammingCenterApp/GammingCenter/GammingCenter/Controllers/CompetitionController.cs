using GammingCenter.DTOs.CompetitionDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GammingCenter.Controllers
    
{
    [ApiController]
    [Route("competition")]
    //[Authorize]
    public class CompetitionController : ControllerBase
    {
        //constructor
        private CompetitionService competitionService;



        public CompetitionController(CompetitionService _competitionService)
        {
            competitionService = _competitionService;
        }

        // ==== view All Competition ====
        //[AllowAnonymous]
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

        // ====Get Competition by Id====
        //[AllowAnonymous]
        [HttpGet("GetCompetitionById/{id}")]
        public IActionResult GetCompetitionById([FromRoute] int id)
        {
            CompetitionOutputDTO competition = competitionService.GetCompetitionById(id);

            if (competition == null)
            {
                return NotFound(); // 404 notfound
            }

            return Ok(competition);   //200 succeeded
        }

        // ==== Create Competition ====
        //[Authorize(Roles = "Admin")]
        [HttpPost("AddDTO")]
        public IActionResult AddDTOCompetition ([FromBody] CompetitionInputDTO competition)
        {
            int id = competitionService.CreateCompetition(competition);
            return Ok(new { CompetitionId = id });
        }

        // ==== Update Competition ====
       
        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateCompetition/{id}")]

        public IActionResult UpdateCompetition ([FromRoute] int id, [FromBody] CompetitionInputDTO competition)
        {
            bool updated = competitionService.UpdateCompetition(id, competition);

            if (!updated)
                return NotFound();

            return Ok("Successfuly Updated"); //return NoContent();
        }

        // ==== Cancel Competition====
        //[Authorize(Roles = "Admin")]
        [HttpPut("CancelCompetition/{id}")]
        public IActionResult CancelCompetition([FromRoute] int id)
        {
            bool cnacelled = competitionService.CancelCompetition(id);
            if (!cnacelled)
                return NotFound();

            return Ok("Successfuly Deleted"); //return NoContent();
        }

        // === Update Competition Status ===
        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateCompetitionStatus/{id}")]
        public IActionResult UpdateCompetitionStatus([FromRoute] int id, [FromQuery]  string status)
        {

            bool updated = competitionService.UpdateCompetitionStatus(id, status);

            if (!updated)
                return NotFound();
            return Ok("Successfuly Updated"); //return NoContent();

        }

        // === Search Competition by Name ===
        //[AllowAnonymous]
        [HttpPut("SearchCompetitionByName")]
        public IActionResult SearchCompetitionByName([FromQuery] string name)
        {
            return Ok(competitionService.SearchCompetitionByName(name));
        }

        // === Search Competition by Status ===
        //[AllowAnonymous]
        [HttpPut("SearchCompetitionByStatus")]
        public IActionResult SearchCompetitionByStatus ([FromQuery]  string status)
        {
            return Ok(competitionService.SearchCompetitionByStatus(status));
        }

    }
}
